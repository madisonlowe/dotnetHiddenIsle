using FluentAssertions;
using HiddenIsle.API.Middleware;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace DotnetHiddenIsle.Tests;

public class NotFoundExceptionHandlerTests
{
    private readonly NotFoundExceptionHandler _handler = new();

    [Fact]
    public async Task TryHandleAsync_WithKeyNotFoundException_Returns404()
    {
        var context = new DefaultHttpContext
        {
            Response = { Body = new MemoryStream() }
        };
        var exception = new KeyNotFoundException("Agent with 123 not found");

        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        handled.Should().BeTrue();
        context.Response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }

    [Fact]
    public async Task TryHandleAsync_WithOtherException_ReturnsFalse()
    {
        var context = new DefaultHttpContext();
        var exception = new InvalidOperationException("Something else went wrong");

        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);

        handled.Should().BeFalse();
        context.Response.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}
