using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Models;

public class NikolaContext :  DbContext 
{
    public NikolaContext(DbContextOptions<NikolaContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBahevior", true);
    }
    public DbSet<Album> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (builder == null)
        {
            return;
        }
        builder.Entity<Album>().ToTable("Album").HasKey(k => k.Id);
        builder.Entity<Artist>().ToTable("Artist").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }

}