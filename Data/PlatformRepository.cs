using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
  private readonly AppDbContext _context;

  public PlatformRepository(AppDbContext context)
  {
    _context = context;
  }

  void IPlatformRepository.CreatePlatform(Platform platform)
  {
    if (platform == null)
      throw new ArgumentNullException(nameof(platform));

    _context.Platforms.Add(platform);
    _context.SaveChanges();
  }

  IEnumerable<Platform> IPlatformRepository.GetAllPlatforms()
  {
    return _context.Platforms.ToList();
  }

  Platform? IPlatformRepository.GetPlatformById(int id)
  {
    return _context.Platforms.FirstOrDefault(p => p.Id == id);
  }
}
