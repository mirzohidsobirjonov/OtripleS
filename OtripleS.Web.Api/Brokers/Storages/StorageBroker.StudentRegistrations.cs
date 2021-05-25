﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OtripleS.Web.Api.Models.StudentRegistrations;

namespace OtripleS.Web.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }

        public async ValueTask<StudentRegistration> InsertStudentRegistrationAsync(
            StudentRegistration StudentRegistration)
        {
            EntityEntry<StudentRegistration> StudentRegistrationEntityEntry =
                await this.StudentRegistrations.AddAsync(StudentRegistration);

            await this.SaveChangesAsync();

            return StudentRegistrationEntityEntry.Entity;
        }

        public IQueryable<StudentRegistration> SelectAllStudentRegistrations() =>
            this.StudentRegistrations.AsQueryable();

        public async ValueTask<StudentRegistration> SelectStudentRegistrationByIdAsync(
            Guid studentId,
            Guid registrationId)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return await this.StudentRegistrations.FindAsync(studentId, registrationId);
        }

        public async ValueTask<StudentRegistration> UpdateStudentRegistrationAsync(
            StudentRegistration StudentRegistration)
        {
            EntityEntry<StudentRegistration> studentRegistrationEntityEntry =
                this.StudentRegistrations.Update(StudentRegistration);

            await this.SaveChangesAsync();

            return studentRegistrationEntityEntry.Entity;
        }

        public async ValueTask<StudentRegistration> DeleteStudentRegistrationAsync(
            StudentRegistration StudentRegistration)
        {
            EntityEntry<StudentRegistration> studentRegistrationEntityEntry =
                this.StudentRegistrations.Remove(StudentRegistration);

            await this.SaveChangesAsync();

            return studentRegistrationEntityEntry.Entity;
        }
    }
}
