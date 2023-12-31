﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextualRPG.API.Contracts;
using TextualRPG.DAL.Data;
using TextualRPG.DAL.Models;

namespace TextualRPG.EF.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly DataContext context;
        public EnemyService(DataContext context)
        {
            this.context = context;
        }

        public async Task<Enemy> AddEnemyAsync(Enemy request)
        {
            await context.Enemies.AddAsync(request);
            await context.SaveChangesAsync();
            return request;
        }

        public async Task<List<Enemy>> GetAllEnemiesAsync()
        {
            var enemies = await context.Enemies.ToListAsync();
            return enemies;
        }

        public async Task<Enemy?> GetEnemyByIdAsync(int id)
        {
            var enemy = await context.Enemies.FirstOrDefaultAsync(e => e.Id == id);

            if (enemy == null)
            {
                return null;
            }

            return enemy;
        }

    }
}
