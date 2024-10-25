using System;

namespace ProdutoAPI.Services;

public class ConfiguracaoManager
{
    private static readonly Lazy<ConfiguracaoManager> _instance =
        new Lazy<ConfiguracaoManager>(() => new ConfiguracaoManager());

    public static ConfiguracaoManager Instance => _instance.Value;

    private ConfiguracaoManager()
    {
        // Inicialização das configurações
    }

    public string GetConfiguracao(string chave)
    {
        // Retorna o valor da configuração baseada na chave
        return "Exemplo de Configuração";
    }
}
