﻿// <auto-generated />
using System;
using BankManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankManagementSystem.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("BankManagementSystem.Models.Accounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("amount");

                    b.Property<DateTime>("created_date");

                    b.Property<int>("currency_id");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("is_blocked");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("currency_id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankManagementSystem.Models.BankTotalBalance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("currency_id");

                    b.Property<double>("value");

                    b.HasKey("id");

                    b.ToTable("BankTotalBalances");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Currencies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("bank_total_balance_id");

                    b.Property<int>("currency_exchange_id");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("short_name")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("id");

                    b.HasIndex("bank_total_balance_id")
                        .IsUnique();

                    b.HasIndex("currency_exchange_id")
                        .IsUnique();

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("BankManagementSystem.Models.CurrencyExchange", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("assigned_time");

                    b.Property<int>("currency_id");

                    b.Property<double>("purchase_value");

                    b.Property<double>("sale_value");

                    b.HasKey("id");

                    b.ToTable("GetCurrencyExchanges");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Operations", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("BankManagementSystem.Models.TransactionHistories", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("amount");

                    b.Property<int>("currency_id");

                    b.Property<int>("operation_id");

                    b.Property<DateTime>("operation_time");

                    b.Property<int>("receiver_account_id");

                    b.Property<int>("sender_account_id");

                    b.HasKey("id");

                    b.HasIndex("currency_id");

                    b.HasIndex("operation_id");

                    b.HasIndex("receiver_account_id");

                    b.HasIndex("sender_account_id");

                    b.ToTable("TransactionHistories");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Users", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BankManagementSystem.Models.Accounts", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Currencies", "currency")
                        .WithMany("accounts")
                        .HasForeignKey("currency_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankManagementSystem.Models.Currencies", b =>
                {
                    b.HasOne("BankManagementSystem.Models.BankTotalBalance", "bankTotalBalance")
                        .WithOne("currency")
                        .HasForeignKey("BankManagementSystem.Models.Currencies", "bank_total_balance_id");

                    b.HasOne("BankManagementSystem.Models.CurrencyExchange", "currencyExchange")
                        .WithOne("currency")
                        .HasForeignKey("BankManagementSystem.Models.Currencies", "currency_exchange_id");
                });

            modelBuilder.Entity("BankManagementSystem.Models.TransactionHistories", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Currencies", "currency")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("currency_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankManagementSystem.Models.Operations", "operation")
                        .WithMany("transactionHistories")
                        .HasForeignKey("operation_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankManagementSystem.Models.Accounts", "receiverAccount")
                        .WithMany("transaction_histories2")
                        .HasForeignKey("receiver_account_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankManagementSystem.Models.Accounts", "senderAccount")
                        .WithMany("transactionHistories")
                        .HasForeignKey("sender_account_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankManagementSystem.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BankManagementSystem.Models.Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
