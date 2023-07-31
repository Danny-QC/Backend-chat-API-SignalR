using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Chat_API_SignalR.Models;

public partial class ChatContext : DbContext
{
    public ChatContext()
    {
    }

    public ChatContext(DbContextOptions<ChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GroupChat> GroupChats { get; set; }

    public virtual DbSet<GroupDetailChat> GroupDetailChats { get; set; }

    public virtual DbSet<MessageChat> MessageChats { get; set; }

    public virtual DbSet<MessageType> MessageTypes { get; set; }

    public virtual DbSet<UserChat> UserChats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupChat>(entity =>
        {
            entity.HasKey(e => e.IdGroupChat).HasName("PK__GroupCha__4771FD424DFAB3BC");

            entity.ToTable("GroupChat");

            entity.Property(e => e.GroupCreation).HasColumnType("datetime");
            entity.Property(e => e.GroupName).IsUnicode(false);
        });

        modelBuilder.Entity<GroupDetailChat>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GroupDetailChat");

            entity.Property(e => e.Joined).HasColumnType("datetime");
            entity.Property(e => e.Left).HasColumnType("datetime");

            entity.HasOne(d => d.IdGroupChatNavigation).WithMany()
                .HasForeignKey(d => d.IdGroupChat)
                .HasConstraintName("FK__GroupDeta__IdGro__3B75D760");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__GroupDeta__IdUse__3A81B327");
        });

        modelBuilder.Entity<MessageChat>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__MessageC__C87C0C9C89AB98A1");

            entity.ToTable("MessageChat");

            entity.Property(e => e.SentHour).HasColumnType("datetime");
            entity.Property(e => e.TextMessage).IsUnicode(false);

            entity.HasOne(d => d.IdGroupChatNavigation).WithMany(p => p.MessageChats)
                .HasForeignKey(d => d.IdGroupChat)
                .HasConstraintName("FK__MessageCh__IdGro__4222D4EF");

            entity.HasOne(d => d.IdMessageTypeNavigation).WithMany(p => p.MessageChats)
                .HasForeignKey(d => d.IdMessageType)
                .HasConstraintName("FK__MessageCh__IdMes__412EB0B6");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.MessageChats)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__MessageCh__IdUse__403A8C7D");
        });

        modelBuilder.Entity<MessageType>(entity =>
        {
            entity.HasKey(e => e.IdMessageType).HasName("PK__MessageT__01EA108C558A42EF");

            entity.ToTable("MessageType");

            entity.Property(e => e.Name).IsUnicode(false);
        });

        modelBuilder.Entity<UserChat>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__UserChat__B7C926386F2956EF");

            entity.ToTable("UserChat");

            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
