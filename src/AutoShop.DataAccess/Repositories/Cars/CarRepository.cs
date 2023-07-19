using AutoShop.DataAccess.Common.Interfaces;
using AutoShop.DataAccess.Interfaces;
using AutoShop.DataAccess.Interfaces.Cars;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Cars;
using Dapper;

namespace AutoShop.DataAccess.Repositories.Cars;

public class CarRepository : BaseRepository, ICarRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from cars";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Car entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.\"cars\"(category, name, image_path, color, type, transmission_is_automatic, made_at, price, description, created_at, updated_at, probeg, manzil, user_id) " +
                "VALUES (@Category, @Name, @ImagePath, @Color, @Type, @TransmissionIsAutomatic, @MadeAt, @Price, @Description, @CreatedAt, @UpdatedAt, @Probeg, @Manzil, @UserId);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM cars WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        { await _connection.CloseAsync(); }
    }

    public async Task<IList<Car>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.cars ORDER BY id desc offset {@params.SkipCount} limit {@params.PageSize}";
            var resCar = (await _connection.QueryAsync<Car>(query)).ToList();
            return (IList<Car>)resCar;
            
        }
        catch
        {
            return new List<Car>();
        }
        finally
        { await _connection.CloseAsync(); }
    }

    public async Task<Car?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string qeury = $"SELECT * FROM cars where id=@Id";            
            var res = await _connection.QuerySingleAsync<Car>(qeury,new {Id = id});
            return res;
            
        }
        catch
        {
            return null;
        }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<IList<Car>> SearchAsync(string search, PaginationParams @params)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.cars WHERE name ILIKE '%{search}%' ORDER BY id DESC OFFSET {@params.SkipCount} LIMIT {@params.PageSize}";
            var cars = await _connection.QueryAsync<Car>(query);
            return cars.ToList();
        }
        catch
        {
            return new List<Car>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> SearchCountAsync(string search)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT COUNT(*) FROM public.cars WHERE name ILIKE '%{search}%'";
            var count = await _connection.ExecuteScalarAsync<int>(query);
            return count;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Car entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.\"cars\" SET category=@Category, name=@Name, image_path=@ImagePath, color=@Color, type=@Type, transmission_is_automatic=@TransmissionIsAutomatic, made_at=@MadeAt, price=@Price, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt, probeg=@Probeg, manzil=@Manzil " +
                $"WHERE id = {id};";
            var resUp = await _connection.ExecuteAsync(query, entity);
            return resUp;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
