﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThriftManager.Infrastructure;

#nullable disable

namespace ThriftManager.Infrastructure.Migrations
{
    [DbContext(typeof(ThriftAppDbContext))]
    partial class ThriftAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ThriftSchema")
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("contributionsession_contributionsessionid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("contributionwallet_contributionwalletid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("group_groupid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("member_memberid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("memberwallet_memberwalletid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("sessionmember_sessionmemberid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("sessionwallettransaction_sessionwallettransactionid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.HasSequence("wallettransaction_wallettransactionid_seq", "ThriftSchema")
                .IncrementsBy(10);

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributingMember", b =>
                {
                    b.Property<long>("ContributingMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "sessionmember_sessionmemberid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContributingMemberId"));

                    b.Property<long>("ContributionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("SlotPosition")
                        .HasColumnType("int");

                    b.HasKey("ContributingMemberId");

                    b.HasIndex("ContributionId");

                    b.ToTable("ContributingMember", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Contribution", b =>
                {
                    b.Property<long>("ContributionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "contributionsession_contributionsessionid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContributionId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ContributionWalletId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContributionId");

                    b.HasIndex("GroupId");

                    b.ToTable("Contribution", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributionWallet", b =>
                {
                    b.Property<long>("ContributionWalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "contributionwallet_contributionwalletid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContributionWalletId"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ContributionId")
                        .HasColumnType("bigint");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContributionWalletId");

                    b.HasIndex("ContributionId")
                        .IsUnique();

                    b.ToTable("ContributionWallet", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributionWalletTransaction", b =>
                {
                    b.Property<long>("ContributionWalletTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "sessionwallettransaction_sessionwallettransactionid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContributionWalletTransactionId"));

                    b.Property<long>("ContributionId")
                        .HasColumnType("bigint");

                    b.Property<long>("ContributionWalletId")
                        .HasColumnType("bigint");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("ContributionWalletTransactionId");

                    b.HasIndex("ContributionWalletId");

                    b.ToTable("ContributionWalletTransaction", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "group_groupid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId");

                    b.ToTable("Group", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "member_memberid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId");

                    b.ToTable("Member", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.MemberWallet", b =>
                {
                    b.Property<int>("MemberWalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberWalletId"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "memberwallet_memberwalletid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("WalletNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberWalletId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("MemberWallet", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.MemberWalletTransaction", b =>
                {
                    b.Property<long>("MemberWalletTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:HiLoSequenceName", "wallettransaction_wallettransactionid_seq")
                        .HasAnnotation("Npgsql:HiLoSequenceSchema", "ThriftSchema")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MemberWalletTransactionId"));

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("MemberWalletId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("MemberWalletTransactionId");

                    b.HasIndex("MemberWalletId");

                    b.ToTable("MemberWalletTransaction", "ThriftSchema");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributingMember", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.Contribution", "Contribution")
                        .WithMany("ContributingMembers")
                        .HasForeignKey("ContributionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contribution");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Contribution", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.Group", "Group")
                        .WithMany("Contributions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.ContributionTimeline", "Timeline", b1 =>
                        {
                            b1.Property<long>("ContributionId")
                                .HasColumnType("bigint");

                            b1.Property<int>("DueDay")
                                .HasMaxLength(11)
                                .HasColumnType("int");

                            b1.Property<int>("Period")
                                .HasColumnType("int");

                            b1.Property<int>("Slots")
                                .HasColumnType("int");

                            b1.HasKey("ContributionId");

                            b1.ToTable("Contribution", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("ContributionId");
                        });

                    b.Navigation("Group");

                    b.Navigation("Timeline")
                        .IsRequired();
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributionWallet", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.Contribution", "Contribution")
                        .WithOne("ContributionWallet")
                        .HasForeignKey("ThriftManager.Domain.Entities.ContributionWallet", "ContributionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.BankAccount", "Account", b1 =>
                        {
                            b1.Property<long>("ContributionWalletId")
                                .HasColumnType("bigint");

                            b1.Property<string>("AccountName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");

                            b1.Property<string>("AccountNo")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("BVN")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.Property<int>("BankId")
                                .HasColumnType("int");

                            b1.HasKey("ContributionWalletId");

                            b1.ToTable("ContributionWallet", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("ContributionWalletId");
                        });

                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Contribution");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributionWalletTransaction", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.ContributionWallet", "ContributionWallet")
                        .WithMany("WalletTransactions")
                        .HasForeignKey("ContributionWalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContributionWallet");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Group", b =>
                {
                    b.OwnsOne("ThriftManager.Domain.ValueObjects.ContributionTimeline", "Timeline", b1 =>
                        {
                            b1.Property<int>("GroupId")
                                .HasColumnType("int");

                            b1.Property<int>("DueDay")
                                .HasMaxLength(11)
                                .HasColumnType("int");

                            b1.Property<int>("Period")
                                .HasColumnType("int");

                            b1.Property<int>("Slots")
                                .HasColumnType("int");

                            b1.HasKey("GroupId");

                            b1.ToTable("Group", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("GroupId");
                        });

                    b.Navigation("Timeline")
                        .IsRequired();
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Member", b =>
                {
                    b.OwnsOne("ThriftManager.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .HasColumnType("int");

                            b1.Property<int>("Hash")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.FullName", "Name", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .HasColumnType("int");

                            b1.Property<string>("First")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Last")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Others")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.MobileNo", "MobileNumber", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .HasColumnType("int");

                            b1.Property<int>("Hash")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.NIN", "NIN", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .HasColumnType("int");

                            b1.Property<int>("Hash")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("MobileNumber")
                        .IsRequired();

                    b.Navigation("NIN")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.MemberWallet", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.Member", "Member")
                        .WithOne("MemberWallet")
                        .HasForeignKey("ThriftManager.Domain.Entities.MemberWallet", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ThriftManager.Domain.ValueObjects.BankAccount", "Account", b1 =>
                        {
                            b1.Property<int>("MemberWalletId")
                                .HasColumnType("int");

                            b1.Property<string>("AccountName")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");

                            b1.Property<string>("AccountNo")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("BVN")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.Property<int>("BankId")
                                .HasColumnType("int");

                            b1.HasKey("MemberWalletId");

                            b1.ToTable("MemberWallet", "ThriftSchema");

                            b1.WithOwner()
                                .HasForeignKey("MemberWalletId");
                        });

                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.MemberWalletTransaction", b =>
                {
                    b.HasOne("ThriftManager.Domain.Entities.MemberWallet", "MemberWallet")
                        .WithMany("MemberWalletTransactions")
                        .HasForeignKey("MemberWalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberWallet");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Contribution", b =>
                {
                    b.Navigation("ContributingMembers");

                    b.Navigation("ContributionWallet")
                        .IsRequired();
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.ContributionWallet", b =>
                {
                    b.Navigation("WalletTransactions");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Group", b =>
                {
                    b.Navigation("Contributions");
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.Member", b =>
                {
                    b.Navigation("MemberWallet")
                        .IsRequired();
                });

            modelBuilder.Entity("ThriftManager.Domain.Entities.MemberWallet", b =>
                {
                    b.Navigation("MemberWalletTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
