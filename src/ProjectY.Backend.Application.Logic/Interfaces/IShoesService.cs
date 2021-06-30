﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectY.Backend.Application.Logic.Models.Shoes;

namespace ProjectY.Backend.Application.Logic.Interfaces
{
    /// <summary>
    /// Сервис для работы с обувью.
    /// </summary>
    public interface IShoesService
    {
        /// <summary>
        /// Создать обувь.
        /// </summary>
        Task<ShoesDto> CreateAsync(CreateShoesDto createShoesDto);

        /// <summary>
        /// Получить обувь по идентификатору.
        /// </summary>
        Task<ShoesDto> GetByIdAsync(long id);

        /// <summary>
        /// Получить все экземпляры обуви.
        /// </summary>
        Task<IEnumerable<ShoesDto>> GetAllAsync();
    }
}