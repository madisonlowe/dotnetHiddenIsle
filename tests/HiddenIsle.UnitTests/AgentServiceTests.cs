using HiddenIsle.API.Data;
using HiddenIsle.API.Models.DTOs.Agent;
using HiddenIsle.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using HiddenIsle.API.Models;
using FluentAssertions;

namespace DotnetHiddenIsle.Tests;

public class AgentServiceTests
{
    private readonly AppDbContext _context;
    private readonly AgentService _service;

    private static List<Agent> CreateTestAgents()
    {
        return
        [
            new Agent
            {
                Id = Guid.NewGuid(),
                Name = "Test Agent 1",
                Inventory = new Inventory
                {
                    Load = 5,
                    Items = ["Item1", "Item2"]
                },
                Contacts =
                [
                    new Contact
                    {
                        Affection = 3,
                        Name = "Contact 1",
                        Description = "A friend.",
                        Card = "The Sun",
                        Land = "Forest",
                        Distance = 2
                    }
                ]
            },
            new Agent
            {
                Id = Guid.NewGuid(),
                Name = "Test Agent 2",
                Inventory = new Inventory
                {
                    Load = 2,
                    Items = ["Item3"]
                },
                Contacts =
                [
                    new Contact
                    {
                        Affection = 5,
                        Name = "Contact 2",
                        Description = "A mentor.",
                        Card = "The Moon",
                        Land = "Mountains",
                        Distance = 3
                    }
                ]
            }
        ];
    }

    public AgentServiceTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _context = new AppDbContext(options);
        _service = new AgentService(_context);
    }

    [Fact]
    public async Task CreateAgentAsync_WithValidAgent_ReturnsCreatedAgent()
    {
        var newAgent = new CreateAgentRequestDto
        {
            Name = "Mara Venn",
            Inventory = new CreateInventoryDTO
            {
                Load = 3,
                Items = ["Silver compass"]
            },
            Contacts =
            {
                new CreateContactDTO
                {
                    Affection = 4,
                    Name = "Ilyra Vale",
                    Description = "A reliable guide.",
                    Card = "The Lantern",
                    Land = "Marshlands",
                    Distance = 1
                }
            }
        };

        var result = await _service.CreateAgentAsync(newAgent, CancellationToken.None);

        result.Should().BeOfType<AgentResponseDto>()
            .Which.Should().BeEquivalentTo(newAgent, options => options.ExcludingMissingMembers());
    }

    //GetAllAgentsAsync
    [Fact]
    public async Task GetAllAgentsAsync_ReturnsAllAgents()
    {
        var testAgents = CreateTestAgents();
        await _context.Agents.AddRangeAsync(testAgents);
        await _context.SaveChangesAsync();

        var result = await _service.GetAllAgentsAsync(CancellationToken.None);

        result.Should().BeOfType<List<AgentResponseDto>>()
            .Which.Should().HaveCount(testAgents.Count)
            .And.ContainEquivalentOf(testAgents.First(), options => options.ExcludingMissingMembers());
    }


    //GetAgentByIdAsync
    [Fact]
    public async Task GetAgentByIdAsync_WithValidId_ReturnsAgent()
    {
        var testAgents = CreateTestAgents();
        await _context.Agents.AddRangeAsync(testAgents);
        await _context.SaveChangesAsync();
        
        var expected = testAgents.Last();
        var result = await _service.GetAgentByIdAsync(
            expected.Id, 
            CancellationToken.None);
        
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetAgentByIdAsync_WithUnknownId_ReturnsNull()
    {
        var unknownId = Guid.NewGuid();

        var result = await _service.GetAgentByIdAsync(
            unknownId,
            CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateAgentAsync_WithValidId_ReturnsUpdatedAgent()
    {
        var agent = CreateTestAgents().First();
        await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();

        var update = new UpdateAgentRequestDto
{
    Class = agent.Class,
    AgentLevel = agent.AgentLevel,
    Name = "Updated name",
    Age = agent.Age,
    Culture = agent.Culture,
    Look = agent.Look,
    AbilityTrackXP = agent.AbilityTrackXP,
    Notes = "Updated notes"
};

        var result = await _service.UpdateAgentAsync(
            agent.Id,
            update,
            CancellationToken.None);

        result.Should().BeEquivalentTo(update, options => options.ExcludingMissingMembers());

        var storedAgent = await _service.GetAgentByIdAsync(agent.Id, CancellationToken.None);
        storedAgent.Should().BeEquivalentTo(update, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public async Task DeleteAgentByIdAsync_WithValidId_RemovesAgent()
    {
        var testAgents = CreateTestAgents();
        await _context.Agents.AddRangeAsync(testAgents);
        await _context.SaveChangesAsync();

        var deletedAgent = testAgents.First();
        var remainingAgent = testAgents.Last();

        await _service.DeleteAgentAsync(deletedAgent.Id, CancellationToken.None);

        var deletedResult = await _service.GetAgentByIdAsync(deletedAgent.Id, CancellationToken.None);
        var remainingResult = await _service.GetAgentByIdAsync(remainingAgent.Id, CancellationToken.None);

        deletedResult.Should().BeNull();
        remainingResult.Should().BeEquivalentTo(remainingAgent);
    }
}
