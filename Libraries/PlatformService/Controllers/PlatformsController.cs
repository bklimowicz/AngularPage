using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo platformRepo;
    private readonly IMapper mapper;
    private readonly ICommandDataClient commandDataClient;

    public PlatformsController(
        IPlatformRepo platformRepo,
        IMapper mapper,
        ICommandDataClient commandDataClient)
    {
        this.platformRepo = platformRepo;
        this.mapper = mapper;
        this.commandDataClient = commandDataClient;
    }

    [HttpGet]    
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("Getting platforms...");

        var platforms = this.platformRepo.GetAllPlatforms();

        return Ok(this.mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = platformRepo.GetPlatformById(id);

        if (platform is null)
        {
            return NotFound($"Missing platform with id {id}.");
        }

        return Ok(this.mapper.Map<PlatformReadDto>(platform));
    }

    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        if (platformCreateDto is null) throw new ArgumentNullException(nameof(platformCreateDto));

        var platform = this.mapper.Map<Platform>(platformCreateDto);
        this.platformRepo.CreatePlatform(platform);

        var platformReadDto = this.mapper.Map<PlatformReadDto>(platform);

        try
        {
            await this.commandDataClient.SendPlatformToCommand(platformReadDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not send synchronously: {ex.Message}");
        }

        return CreatedAtRoute(nameof(GetPlatformById), new { id = platformReadDto.Id }, platformReadDto);
    }
}
