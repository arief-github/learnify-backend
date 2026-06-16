using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILogger logger)
        {
            try
            {
                await SeedEntityAsync(context, context.Categories, "../Infrastructure/Seed/categories.json");
                await SeedEntityAsync(context, context.Courses, "../Infrastructure/Seed/courses.json");
                await SeedEntityAsync(context, context.Requirements, "../Infrastructure/Seed/requirements.json");
                await SeedEntityAsync(context, context.Learnings, "../Infrastructure/Seed/learnings.json");
            }
            catch (Exception ex)
            {
                // jika json tidak cocok saat dilakukan convert. throw error exception
                logger.LogError(ex.Message);
            }
        }

        private static async Task SeedEntityAsync<T>(
            StoreContext context, 
            DbSet<T> dbSet, 
            string filePath) where T : class
        {
            // 1. skip jika data sudah ada
            if (await dbSet.AnyAsync())
            {
                return;
            }

            // 2. baca file json secara asynchronous
            var jsonData = await File.ReadAllTextAsync(filePath);

            // 3. konversi json ke list<T>
            var entities = JsonSerializer.Deserialize<List<T>>(jsonData);

            // 4. guard clause — skip jika null/empty
            if (entities is not { Count: > 0 })
            {
                return;
            }

            // 5. masukkan data ke DB
            await dbSet.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }
}