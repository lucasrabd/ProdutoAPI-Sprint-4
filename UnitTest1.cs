
using Xunit;
using Moq;
using ProdutoAPI.Services;
using System.Net.Http;
using System.Threading.Tasks;

public class FirebaseAuthServiceTests
{
    private readonly Mock<HttpClient> _httpClientMock;
    private readonly FirebaseAuthService _authService;

    public FirebaseAuthServiceTests()
    {
        _httpClientMock = new Mock<HttpClient>();
        _authService = new FirebaseAuthService(_httpClientMock.Object);
    }

    [Fact]
    public async Task RegisterUser_ShouldReturnToken()
    {
        var token = await _authService.RegisterUser("test@example.com", "password123");
        Assert.NotNull(token);
    }

    [Fact]
    public async Task LoginUser_ShouldReturnToken()
    {
        var token = await _authService.LoginUser("test@example.com", "password123");
        Assert.NotNull(token);
    }
}
