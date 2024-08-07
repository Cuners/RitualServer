﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RitualServer.Model;

public partial class RitualbdContext : DbContext
{
    public RitualbdContext()
    {
    }

    public RitualbdContext(DbContextOptions<RitualbdContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CategoiresService> CategoiresServices { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Clothe> Clothes { get; set; }

    public virtual DbSet<Coffin> Coffins { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Conservation> Conservations { get; set; }

    public virtual DbSet<Cross> Crosses { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Monument> Monuments { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<StatusVehicle> StatusVehicles { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<Tape> Tapes { get; set; }

    public virtual DbSet<TypeParticipant> TypeParticipants { get; set; }

    public virtual DbSet<Urn> Urns { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientOrder> ClientOrders { get; set; }

    public virtual DbSet<UsersOrder> UsersOrders { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VlozheniaMess> VlozheniaMesses { get; set; }

    public virtual DbSet<WareHouse> WareHouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
        });

        modelBuilder.Entity<CategoiresService>(entity =>
        {
            entity.HasKey(e => e.CategoriesServicesId);

            entity.Property(e => e.CategoriesServicesId).HasColumnName("CategoriesServicesID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Clothe>(entity =>
        {
            entity.HasKey(e => e.ClothId);

            entity.Property(e => e.ClothId).HasColumnName("ClothID");
            entity.Property(e => e.ColorId).HasColumnName("Color_ID");
            entity.Property(e => e.MaterialId).HasColumnName("Material_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Color).WithMany(p => p.Clothes)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Clothes_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Clothes)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Clothes_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Clothes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Clothes_Products");
        });

        modelBuilder.Entity<Coffin>(entity =>
        {
            entity.Property(e => e.CoffinId).HasColumnName("CoffinID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Color).WithMany(p => p.Coffins)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Coffins_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Coffins)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Coffins_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Coffins)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Coffins_Products");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
        });

        modelBuilder.Entity<Conservation>(entity =>
        {
            entity.Property(e => e.ConservationId).HasColumnName("ConservationID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatorId).HasColumnName("Creator_id");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
            entity.Property(e => e.TypeId).HasColumnName("Type_Conservation");
            entity.HasOne(d => d.Creator).WithMany(p => p.Conservations)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("FK_Conservations_Users");
            entity.HasOne(d => d.Type).WithMany(p => p.Conservations)
               .HasForeignKey(d => d.TypeId)
               .HasConstraintName("FK_Conservations_TypeParticipants");
          
        });

        modelBuilder.Entity<Cross>(entity =>
        {
            entity.Property(e => e.CrossId).HasColumnName("CrossID");
            entity.Property(e => e.ColorId).HasColumnName("Color_ID");
            entity.Property(e => e.MaterialId).HasColumnName("Material_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Color).WithMany(p => p.Crosses)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Crosses_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Crosses)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Crosses_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Crosses)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Crosses_Products");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_At");
            entity.Property(e => e.Message1).HasColumnName("Message");
            entity.Property(e => e.RazgovorId).HasColumnName("Razgovor_ID");
            entity.Property(e => e.SenderId).HasColumnName("Sender_ID");

            entity.HasOne(d => d.Razgovor).WithMany(p => p.Messages)
                .HasForeignKey(d => d.RazgovorId)
                .HasConstraintName("FK_Messages_Conservations");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK_Messages_Users");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.Property(e => e.ModelId).HasColumnName("ModelID");
        });

        modelBuilder.Entity<Monument>(entity =>
        {
            entity.Property(e => e.MonumentId).HasColumnName("MonumentID");
            entity.Property(e => e.ColorId).HasColumnName("Color_id");
            entity.Property(e => e.MaterialId).HasColumnName("Material_id");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Color).WithMany(p => p.Monuments)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Monuments_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Monuments)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Monuments_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Monuments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Monuments_Products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("StatusId");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Orders_StatusOrder");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.Property(e => e.OrderServiceId)
                .ValueGeneratedOnAdd()
                .HasColumnName("OrderServiceID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderService)
                .HasForeignKey(d => d.OrderServiceId)
                .HasConstraintName("FK_OrderServices_Orders");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_OrderServices_Services");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConservationId).HasColumnName("Conservation_id");
            entity.Property(e => e.IsArchived).HasColumnName("Is_Archived");
            entity.Property(e => e.IsPinned).HasColumnName("Is_Pinned");
           
            entity.Property(e => e.UsersId).HasColumnName("Users_id");

            entity.HasOne(d => d.Conservation).WithMany(p => p.Participants)
                .HasForeignKey(d => d.ConservationId)
                .HasConstraintName("FK_Participants_Conservations");

            entity.HasOne(d => d.Users).WithMany(p => p.Participants)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_Participants_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId);

            entity.Property(e => e.RolesId).HasColumnName("RolesID");
            entity.Property(e => e.Role1).HasColumnName("Role");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServicesId);

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Services_CategoiresServices");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_Shipments_Orders");
        });



        modelBuilder.Entity<StatusVehicle>(entity =>
        {
            entity.ToTable("StatusVehicle");

            entity.Property(e => e.StatusVehicleId).HasColumnName("StatusVehicleID");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.ToTable("StatusOrder");

            entity.Property(e => e.StatusOrderId).HasColumnName("StatusOrderID");
        });

        modelBuilder.Entity<Tape>(entity =>
        {
            entity.Property(e => e.TapeId).HasColumnName("TapeID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Color).WithMany(p => p.Tapes)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Tapes_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Tapes)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Tapes_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Tapes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Tapes_Products");
        });

        modelBuilder.Entity<TypeParticipant>(entity =>
        {
            entity.HasKey(e => e.TypeParticipantsId);

            entity.Property(e => e.TypeParticipantsId).HasColumnName("TypeParticipantsID");
        });

        modelBuilder.Entity<Urn>(entity =>
        {
            entity.Property(e => e.UrnId).HasColumnName("UrnID");
            entity.Property(e => e.ColorId).HasColumnName("Color_ID");
            entity.Property(e => e.MaterialId).HasColumnName("Material_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Color).WithMany(p => p.Urns)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK_Urns_Colors");

            entity.HasOne(d => d.Material).WithMany(p => p.Urns)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Urns_Materials");

            entity.HasOne(d => d.Product).WithMany(p => p.Urns)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Urns_Products");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Roles).WithMany(p => p.Users)
               .HasForeignKey(d => d.RoleId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity <Client>(entity =>
        {
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
        });

        modelBuilder.Entity<ClientOrder>(entity =>
        {
            entity.HasKey(e => e.ClientOrdersID); ;
           
            entity.Property(e => e.ClientID).HasColumnName("ClientID");

            entity.Property(e => e.OrderID).HasColumnName("OrderID");

            entity.HasOne(d => d.Clients).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.ClientID)
                .HasConstraintName("FK_ClientOrders_Client");

            entity.HasOne(d => d.Orders).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK_ClientOrders_Orders");
        });

        modelBuilder.Entity<UsersOrder>(entity =>
        {
            entity.HasKey(e => e.UsersOrderID);
            entity.Property(e => e.UserID).HasColumnName("UserID");

            entity.Property(e => e.OrderID).HasColumnName("OrderID");

            entity.HasOne(d => d.Users).WithMany(p => p.UsersOrders)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK_UsersOrders_Users");

            entity.HasOne(d => d.Orders).WithMany(p => p.UsersOrders)
                .HasForeignKey(d => d.OrderID)
                .HasConstraintName("FK_UsersOrders_Orders");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.LastMaintenanceDate).HasColumnType("datetime");
            entity.Property(e => e.ModelId).HasColumnName("ModelID");
            entity.Property(e => e.NextMaintenanceDate).HasColumnType("datetime");
            entity.Property(e => e.ServicesId).HasColumnName("Services_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

            entity.HasOne(d => d.Brand).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Vehicles_Brands");

            entity.HasOne(d => d.Model).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK_Vehicles_Models");

            entity.HasOne(d => d.Services).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ServicesId)
                .HasConstraintName("FK_Vehicles_Services");

            entity.HasOne(d => d.Status).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Vehicles_StatusVehicle");
        });

        modelBuilder.Entity<VlozheniaMess>(entity =>
        {
            entity.ToTable("VlozheniaMess");

            entity.Property(e => e.VlozheniaMessId).HasColumnName("VlozheniaMessID");
            entity.Property(e => e.FileUrl).HasColumnName("File_Url");
            entity.Property(e => e.MessageId).HasColumnName("Message_id");

            entity.HasOne(d => d.Message).WithMany(p => p.VlozheniaMesses)
                .HasForeignKey(d => d.MessageId)
                .HasConstraintName("FK_VlozheniaMess_Messages");
        });

        modelBuilder.Entity<WareHouse>(entity =>
        {
            entity.HasKey(e => e.CompositionId);

            entity.Property(e => e.CompositionId).HasColumnName("CompositionID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.WareHouses)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_WareHouses_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
