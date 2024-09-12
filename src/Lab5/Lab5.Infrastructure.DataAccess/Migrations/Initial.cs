using FluentMigrator;
using Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>

    """
     create type transaction_type as enum
     (
         'withdrawal',
         'depositing'
     );
 
 
     create table users
     (
         user_id bigint primary key generated always as identity ,
         user_name text not null ,
         user_role string not null ,
         user_account_number bigint not references accounts(account_id) ,
         user_account_pin int not null
     );
 
     create table transactions
     (
         id bigint primary key generated always as identity ,
         user_id bigint references users(user_id) ,
         transaction_type transaction_type not null ,
         transaction_amount int not null
 
     );
 
     create table accounts
     (
         account_id bigint primary key generated always as identity ,
         user_id bigint references users(user_id),
         balance bigint not null
     );
     """;
    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table transactions;
    drop table accounts;

    drop type transaction_type;
    """;
}