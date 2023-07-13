﻿using Npgsql;

namespace AutoShop.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepository()
    {
        //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=avto-bazar-db; User Id=postgres; Password=9639;");

    }
}
