using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_API.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "color_info",
                columns: table => new
                {
                    color_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    color_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color_info", x => x.color_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_inf",
                columns: table => new
                {
                    customer_inf_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    customer_name = table.Column<string>(nullable: true),
                    identity_card_type = table.Column<int>(nullable: false),
                    identity_card_no = table.Column<string>(nullable: true),
                    mobile_phone = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    user_money = table.Column<decimal>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    register_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_inf", x => x.customer_inf_id);
                });

            migrationBuilder.CreateTable(
                name: "customer_login",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    user_stats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_login", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "order_cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    product_amount = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    add_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_cart", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    order_detail_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    product_name = table.Column<string>(nullable: true),
                    product_cnt = table.Column<int>(nullable: false),
                    product_price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => x.order_detail_id);
                });

            migrationBuilder.CreateTable(
                name: "order_master",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_sn = table.Column<string>(nullable: true),
                    customer_id = table.Column<int>(nullable: false),
                    payment_method = table.Column<int>(nullable: false),
                    order_money = table.Column<decimal>(nullable: false),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_master", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "product_info",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_core = table.Column<string>(nullable: true),
                    product_name = table.Column<string>(nullable: true),
                    brand_name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    publish_status = table.Column<int>(nullable: false),
                    weight = table.Column<float>(nullable: false),
                    length = table.Column<float>(nullable: false),
                    height = table.Column<float>(nullable: false),
                    width = table.Column<float>(nullable: false),
                    color_type = table.Column<int>(nullable: false),
                    indate = table.Column<string>(nullable: true),
                    descript = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_info", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "productpicinfo",
                columns: table => new
                {
                    product_pic_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    pic_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productpicinfo", x => x.product_pic_id);
                });

            migrationBuilder.CreateTable(
                name: "warehouse_product",
                columns: table => new
                {
                    wp_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    current_cnt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_product", x => x.wp_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "color_info");

            migrationBuilder.DropTable(
                name: "customer_inf");

            migrationBuilder.DropTable(
                name: "customer_login");

            migrationBuilder.DropTable(
                name: "order_cart");

            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "order_master");

            migrationBuilder.DropTable(
                name: "product_info");

            migrationBuilder.DropTable(
                name: "productpicinfo");

            migrationBuilder.DropTable(
                name: "warehouse_product");
        }
    }
}
