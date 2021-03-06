﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Together.Activity.Domain.AggregatesModel.ActivityAggregate;

namespace Together.Activity.Infrastructure.EntityTypeConfigurations
{
    public class ActivityEntityTypeConfiguration
        : IEntityTypeConfiguration<Domain.AggregatesModel.ActivityAggregate.Activity>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ActivityAggregate.Activity> builder)
        {
            builder.ToTable("activities");

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(a => a.Id)
                .ForSqlServerUseSequenceHiLo("activityseq");

            builder.Property(a => a.ActivityTime)
                .IsRequired();
            builder.Property(a => a.CreateTime)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
            builder.Property(a => a.OwnerId)
                .IsRequired(false);
            builder.Property<int>("ActivityStatusId")
                .IsRequired();
            builder.Property(a => a.Address)
                .HasMaxLength(200)
                .IsRequired(true);
            builder.Property(a => a.Description)
                .IsRequired(false);
            builder.Property(a => a.Details)
                .IsRequired(false);
            builder.Property(a => a.EndTime)
                .IsRequired();
            builder.Property(a => a.LimitsNum);

            builder.HasOne(a => a.ActivityStatus)
                .WithMany()
                .HasForeignKey("ActivityStatusId");

            var navigation = builder.Metadata
                .FindNavigation(nameof(Domain.AggregatesModel.ActivityAggregate.Activity.Participants));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
