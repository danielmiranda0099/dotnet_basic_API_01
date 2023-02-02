
public class TimeMiddleware {
    readonly RequestDelegate next;//DECLARACION  de la propiedad que posibilita llamar al siguiente middleware

    public TimeMiddleware(RequestDelegate nextRequest) {
        next = nextRequest;
    }

    //Toda la informacion de la REQUEST viene en el parametro CONTEXT
    public async Task Invoke(HttpContext context) {

        //pregunto si en la URL esta el parametro ?time
        if(context.Request.Query.Any( parametro => parametro.Key == "time" )){
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            return;
        }
            await next(context);

    }
}

//Permite agregar el Middleware a la COLA de Middleware
public static class TimeMiddlewareExtension {
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<TimeMiddleware>();
    }
}