using AutoMapper;
using EquipmentRental.BLL.DTO.Equipment;
using EquipmentRental.DAL.Entity;
using EquipmentRental.DAL.Repositories;
using EquipmentRental.DAL.UnitOfWork;
using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentRental.BLL.Services.Implementation
{
	public class EquipmentService : IEquipmentService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IEquipmentRepository _equipments;

		public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_equipments = unitOfWork.Equipments;
		}

		public async Task<EquipmentDTO> CreateAsync(CreateEquipmentDTO equipment)
		{
			var mapped = _mapper.Map<Equipment>(equipment);
			var result = await _equipments.AddAsync(mapped);
			await _unitOfWork.SaveAsync();
			var mappedResult = _mapper.Map<EquipmentDTO>(result);
			mappedResult.Condition = await CalculateEquipmentCondition(mappedResult.Id);
			return mappedResult;
		}

		public async Task<EquipmentDTO> DeleteAsync(int equipmentId)
		{
			var equipment = await _equipments.GetByIdAsync(equipmentId);
			if (equipment != null)
			{
				var deleted = await _equipments.DeleteAsync(equipment);
				await _unitOfWork.SaveAsync();
				return _mapper.Map<EquipmentDTO>(equipment);
			}

			return null;
		}

		public async Task<IEnumerable<EquipmentDTO>> FindAllEquipmentsAsync()
		{
			var equipments = await _equipments.GetAllAsync();
			var mappedEquipments = _mapper.Map<IEnumerable<EquipmentDTO>>(equipments);

			foreach(var equipment in mappedEquipments)
			{
				equipment.Condition = await CalculateEquipmentCondition(equipment.Id);
			}

			return mappedEquipments;
		}

		public async Task<EquipmentDTO> FindByIdAsync(int equipmentId)
		{
			var equipment = await _equipments.GetByIdAsync(equipmentId);
			var mapped = _mapper.Map<EquipmentDTO>(equipment);
			mapped.Condition = await CalculateEquipmentCondition(equipmentId);
			return mapped;
		}

		public async Task<EquipmentDTO> UpdateAsync(UpdateEquipmentDTO equipmentToUpdate)
		{
			var equipment = await _equipments.GetByIdAsync(equipmentToUpdate.Id);
			equipment = _mapper.Map(equipmentToUpdate, equipment);

			var updated = await _equipments.UpdateAsync(equipment);
			await _unitOfWork.SaveAsync();

			var mappedResult = _mapper.Map<EquipmentDTO>(updated);
			mappedResult.Condition = await CalculateEquipmentCondition(mappedResult.Id);
			return mappedResult;
		}


		public async Task<string> GenerateReportInExcel(int equipmentId)
		{
			var equipment = await _equipments.GetByIdAsync(equipmentId);
			var orders = await _unitOfWork.Orders.GetAllAsync();
			var equipmentOrders = orders.Where(o => o.EquipmentId == equipmentId);

			WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
			var sheet = workbook.CreateWorkSheet($"Equipment {equipment.Name} info!");

			sheet["A1"].Value = $"Equipment {equipment.Name} info!";

			sheet["A2"].Value = "Name";
			sheet["B2"].Value = equipment.Name;

			sheet["A3"].Value = "Initial Price";
			sheet["B3"].Value = equipment.InitialPrice;

			sheet["A4"].Value = "Userful Life";
			sheet["B4"].Value = equipment.UsefulLife + " years";

			sheet["A5"].Value = "Credit Term";
			sheet["B5"].Value = equipment.CreditTerm.ToShortDateString();

			sheet["A6"].Value = "Condition";
			double condition = await CalculateEquipmentCondition(equipmentId);
			sheet["B6"].Value = condition.ToString() + "%";

			sheet["A7"].Value = "Orders";

			sheet["A8"].Value = "FROM";
			sheet["B8"].Value = "TO";

			int counter = 9;
			foreach (var order in equipmentOrders)
			{
				sheet[$"A{counter}"].Value = order.From.ToShortDateString();
				sheet[$"B{counter}"].Value = order.To.ToShortDateString();

				counter++;
			}

			string path = @$"D:\equipment{equipmentId}.xlsx";
			workbook.SaveAs(path);
			return path;
		}

		private async Task<double> CalculateEquipmentCondition(int equipmentId)
		{
			var equipment = await _equipments.GetByIdAsync(equipmentId);

			//киос = C / CПИ / ПС * 100%
			double condition = equipment.InitialPrice 
				/ equipment.UsefulLife 
				/ equipment.InitialPrice * 100;

			return Math.Round(condition, 2);
		}
	}
}
