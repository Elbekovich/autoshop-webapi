using AutoShop.DataAccess.Interfaces.Users;
using AutoShop.DataAccess.Utils;
using AutoShop.DataAccess.ViewModels.Users;
using AutoShop.Domain.Entities.Users;
using Dapper;

namespace AutoShop.DataAccess.Repositories.Users
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"select count(*) from users";
                var result = await _connection.QuerySingleAsync<long>(query);
                return result;
            }
            catch { return 0; }
            finally { await _connection.CloseAsync(); }
        }

        //public async Task<int> Register(User entity)
        //{
        //    try
        //    {
        //        await _connection.OpenAsync();
        //        string query = "";
        //    }
        //}

        public async Task<int> CreateAsync(User entity)
        {
            try
            {
                await _connection.OpenAsync();
                //string query = "INSERT INTO public.users(first_name, last_name, phone_number, birth_date, region, email, password_hash,salt,created_at, updated_at)" +
                //    "VALUES (@FirstName, " +
                //    "@LastName, " +
                //    "@PhoneNumber, " +
                //    "@BirthDate, " +
                //    "@Region, " +
                //    "@PasswordHash," +
                //    "@Salt," +
                //    "@CreatedAt, " +
                //    "@Email" +
                //    "@UpdatedAt);";
                string query = "INSERT INTO public.users(first_name, last_name, phone_number, birth_date, region, password_hash, salt, created_at, updated_at, email)" +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @BirthDate, @Region, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @Email);";
                var result = await _connection.ExecuteAsync(query, entity);
                return result;
            }
            catch { return 0; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<int> DeleteAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "DELETE FROM users WHERE id=@Id";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
                return result;
            }
            catch { return 0; }
            finally { await _connection.CloseAsync(); }
        }
        public async Task<IList<User>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM public.users ORDER BY id desc offset {@params.SkipCount} limit {@params.PageSize}";
                var result = (await _connection.QueryAsync<User>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<User>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM users where id=@Id";
                var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });
                return result;
            }
            catch
            {
                return null;
            }
            finally { await _connection.CloseAsync(); }
        }

        public Task<UserViewModel> GetUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<(int ItemsCount, IList<User>)> SearchAsync(string search, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(long id, User entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "UPDATE public.users SET " +
                    "first_name = @FirstName, " +
                    "last_name = @LastName, " +
                    "phone_number = @PhoneNumber, " +
                    "birth_date = @BirthDate, " +
                    "region = @Region, " +
                    "password_hash = @PasswordHash, " +
                    "salt = @Salt, " +
                    "created_at = @CreatedAt, " +
                    "updated_at = @UpdatedAt, " +
                    "email = @Email " +
                    "WHERE id = @Id";

                entity.Id = id; 

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
