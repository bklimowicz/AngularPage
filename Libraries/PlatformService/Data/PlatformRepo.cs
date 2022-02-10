using PlatformService.Models;

namespace PlatformService.Data;
public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext context;

    public PlatformRepo(AppDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException($"Missing {nameof(AppDbContext)} parameter.");
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform is null) throw new ArgumentNullException(nameof(platform));

        this.context.Platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms() => this.context.Platforms.ToList();

    public Platform? GetPlatformById(int id) => this.context.Platforms.FirstOrDefault(p => p.Id == id) ?? null;
    public bool SaveChanges()
    {
        return (this.context.SaveChanges() >= 0);
    }
}