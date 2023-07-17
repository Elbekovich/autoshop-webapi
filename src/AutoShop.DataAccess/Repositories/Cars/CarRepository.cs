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
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            //   string query = "INSERT INTO public.cars(category_id, name, image_path, color, type, transmission_is_automatic, made_at, price, description,  created_at, updated_at, probeg)" +
            //"VALUES (@CategoryId, @Name, @ImagePath, @Color, @Type, @TransmissionIsAutomatic, @MadeAt, @Price, @Description,  @CreatedAt, @UpdatedAt, @Probeg));";
            string query = "INSERT INTO public.\"cars\"(category_id, name, image_path, color, type, transmission_is_automatic, made_at, price, description, created_at, updated_at, probeg) " +
                "VALUES (@CategoryId, @Name, @ImagePath, @Color, @Type, @TransmissionIsAutomatic, @MadeAt, @Price, @Description, @CreatedAt, @UpdatedAt, @Probeg);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch(Exception ex) 
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
        //throw new NotImplementedException();
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

    public Task<(int ItemsCount, IList<Car>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Car entity)
    {
        //throw new NotImplementedException();
        try
        {
            await _connection.OpenAsync();
            //car id ni tashab ketganman agar xatolik bersa shu yerda
            //string query = $"UPDATE public.\"cars\" " +
            //    $"SET category_id=@CategoryId, name=@Name, image_path=@ImagePath, color=@Color, type=@Type, transmission_is_automatic=@TransmissionIsAutomatic, made_at=@MadeAt, price=@Price, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt, probeg=@Probeg" +
            //    $"WHERE id={id};";

            string query = $"UPDATE public.\"cars\" " +
                $"SET category_id=@CategoryId, name=@Name, image_path=@ImagePath, color=@Color, type=@Type, transmission_is_automatic=@TransmissionIsAutomatic, made_at=@MadeAt, price=@Price, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt, probeg=@Probeg " +
                $"WHERE id={id};";


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
