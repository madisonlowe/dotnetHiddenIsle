using HiddenIsle.API.Data;
using HiddenIsle.API.Models.DTOs.Agents;
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

        result.Should().HaveCount(testAgents.Count);
        result.Select(agent => agent.Id).Should().BeEquivalentTo(testAgents.Select(agent => agent.Id));
        result.Select(agent => agent.Name).Should().BeEquivalentTo(testAgents.Select(agent => agent.Name));
    }


    //GetAgentByIdAsync
    [Fact]
    public async Task GetAgentByIdAsync_WithValidId_ReturnsAgent()
    {
        var testAgents = CreateTestAgents();
        await _context.Agents.AddRangeAsync(testAgents);
        await _context.SaveChangesAsync();
        _context.ChangeTracker.Clear();

        var expected = testAgents.Last();
        var result = await _service.GetAgentByIdAsync(
            expected.Id,
            CancellationToken.None);

        result.Should().NotBeNull();
        result.Id.Should().Be(expected.Id);
        result.Name.Should().Be(expected.Name);
        result.Inventory.Should().BeEquivalentTo(expected.Inventory);
        result.AgentLevel.Should().Be(expected.AgentLevel);
        result.Contacts.Should().BeEquivalentTo(expected.Contacts);
    }

    [Fact]
    public async Task GetAgentByIdAsync_WithUnknownId_ThrowsKeyNotFoundException()
    {
        var unknownId = Guid.NewGuid();

        var act = async () => await _service.GetAgentByIdAsync(
            unknownId,
            CancellationToken.None);

        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"*Agent with {unknownId} not found*");
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

        result.Id.Should().Be(agent.Id);
        result.Name.Should().Be("Updated name");
        result.Notes.Should().Be("Updated notes");

        var storedAgent = await _service.GetAgentByIdAsync(agent.Id, CancellationToken.None);
        storedAgent.Id.Should().Be(agent.Id);
        storedAgent.Name.Should().Be("Updated name");
        storedAgent.Notes.Should().Be("Updated notes");
    }

    [Fact]
    public async Task UpdateAgentAsync_WithUnknownId_ThrowsKeyNotFoundException()
    {
        var unknownId = Guid.NewGuid();
        var update = new UpdateAgentRequestDto
        {
            Name = "Updated name",
            Notes = "Updated notes"
        };

        var act = async () => await _service.UpdateAgentAsync(
            unknownId,
            update,
            CancellationToken.None);

        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage($"*Agent with ID {unknownId} not found*");
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

        var act = async () => await _service.GetAgentByIdAsync(deletedAgent.Id, CancellationToken.None);
        await act.Should().ThrowAsync<KeyNotFoundException>();

        var remainingResult = await _service.GetAgentByIdAsync(remainingAgent.Id, CancellationToken.None);
        remainingResult.Id.Should().Be(remainingAgent.Id);
        remainingResult.Name.Should().Be(remainingAgent.Name);
    }
}
