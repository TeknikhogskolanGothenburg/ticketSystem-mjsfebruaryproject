using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TicketShopProject.Data;

namespace TicketShopProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180214162508_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketShopProject.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<string>("ZipCodeOrAppartmentNumber");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<int>("TicketId");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("TicketId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("ShoppingCartId");

                    b.Property<int?>("TicketId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("TicketId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<bool>("IsPreferredTicket");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("TicketId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("TicketShopProject.Data.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TicketShopProject.Data.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("TicketShopProject.Data.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId");
                });

            modelBuilder.Entity("TicketShopProject.Data.Models.Ticket", b =>
                {
                    b.HasOne("TicketShopProject.Data.Models.Category", "Category")
                        .WithMany("Tickets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
