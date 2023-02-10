using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculateVatAPI.Migrations
{
    /// <inheritdoc />
    public partial class Populate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Countries (name) values ('France')");
            mb.Sql("insert into Countries (name) values ('United Kingdom')");
            mb.Sql("insert into Countries (name) values ('Portugal')");
            mb.Sql("insert into Countries (name) values ('Spain')");

            mb.Sql("insert into CountriesVats (vat,countryid) values (5.5,(select id from Countries where name = 'France'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (20,(select id from Countries where name = 'France'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (10,(select id from Countries where name = 'France'))");

            mb.Sql("insert into CountriesVats (vat,countryid) values (5,(select id from Countries where name = 'United Kingdom'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (20,(select id from Countries where name = 'United Kingdom'))");

            mb.Sql("insert into CountriesVats (vat,countryid) values (6,(select id from Countries where name = 'Portugal'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (13,(select id from Countries where name = 'Portugal'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (23,(select id from Countries where name = 'Portugal'))");

            mb.Sql("insert into CountriesVats (vat,countryid) values (21,(select id from Countries where name = 'Spain'))");
            mb.Sql("insert into CountriesVats (vat,countryid) values (10,(select id from Countries where name = 'Spain'))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
