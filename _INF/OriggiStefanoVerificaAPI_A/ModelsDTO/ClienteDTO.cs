namespace OriggiStefanoVerificaAPI_A;

public class ClienteDTO
{
    public int ClienteId { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public int NumeroCartaDiCredito { get; set; }
    public string Citta { get; set; } = null!;

    public ClienteDTO(){}
    public ClienteDTO(Cliente cliente) => (ClienteId,Nome,Cognome,NumeroCartaDiCredito,Citta) 
    = (cliente.ClienteId,cliente.Nome,cliente.Cognome,cliente.NumeroCartaDiCredito,cliente.Citta);
    
}
