using AutoShop.DataAccess.Interfaces.Sellers;
using AutoShop.DataAccess.Utils;
using AutoShop.Domain.Entities.Sellers;
using Dapper;

namespace AutoShop.DataAccess.Repositories.Sellers
{
    public class SellerRepository : BaseRepository,ISellerRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"select count(*) from seller";
                var result = await _connection.QuerySingleAsync<long>(query);
                return result;
            }
            catch 
            {
                return 0;
            }
            finally { await  _connection.CloseAsync(); }    
        }

        public async Task<int> CreateAsync(Seller entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.\"seller\"(seller_id, first_name, last_name, birth_date, phone_number, region, created_at, updated_at) " +
                    "VALUES (@SellerId, @FirstName, @LastName, @BirthDate, @PhoneNumber, @Region, @CreatedAt, @UpdatedAt );";
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
                string query = "DELETE FROM seller WHERE id=@Id";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
                return result;
            }
            catch
            {
                return 0;
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<IList<Seller>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM public.\"seller\" ORDER BY id desc offset {@params.SkipCount} limit {@params.PageSize}";
                var result = (await _connection.QueryAsync<Seller>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Seller>();
            }
            finally { await _connection.CloseAsync(); }
            
        }

        public async Task<Seller?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM seller where id=@Id";
                var result = await _connection.QuerySingleAsync<Seller>(query, new { Id = id });
                return result;
            }
            catch
            {
                return null;
            }
            finally { await _connection.CloseAsync(); }
        }

        public Task<(int ItemsCount, IList<Seller>)> SearchAsync(string search, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(long id, Seller entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"UPDATE public.\"seller\"" +
                    $"SET seller_id=@SellerId, first_name=@FirstName, last_name=@LastName, birth_date=@BirthDate, phone_number=@PhoneNumber, region=@Region, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                    $"WHERE id={id};";
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
    }
}
