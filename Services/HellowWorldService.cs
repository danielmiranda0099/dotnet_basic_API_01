

public class HellowWorldService : IHellowWorldService {
    public string GetHellowWorld() {
        return "Hello World";
    }
}

//Creacion de la "INTERFAZ" (Las interfaces nos ayudan a crear tipos abstractos)
//Nos ayudan a INYECTAR dependencias de una forma mas facil
//la interfaz solo expone los METODOS mas no la implementacion
public interface IHellowWorldService {
    string GetHellowWorld();
}