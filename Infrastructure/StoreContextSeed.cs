using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entity;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILogger logger)
        {
            try
            {
                if (!context.Courses.Any())
                {
                    // 1. read file json secara asynchronous
                    var coursesData = await File.ReadAllTextAsync("../Infrastructure/Seed/courses.json");
                    
                    // 2. konvert json kedalam list courses.
                    var courses = JsonSerializer.Deserialize <List<Course>> (coursesData);

                    // throw return jika courses null
                    if (courses == null)
                    {
                        return;
                    }
                    
                    // jika hasil konversi cocok, masukkan data ke dalam DB
                    foreach (var item in courses)
                    {
                        context.Courses.Add(item);
                    }
                    
                    // save changes to DB
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // jika json tidak cocok saat dilakukan convert. throw error exception
                logger.LogError(ex.Message);
            }
        }
    }
}