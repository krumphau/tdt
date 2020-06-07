
using app = app.app;

using flash = flask.flash;

using request = flask.request;

using jsonify = flask.jsonify;

public static class test {
    
    [app.route("/test")]
    public static object test() {
        try {
            var resp = jsonify("App is healthy");
            resp.status_code = 200;
            return resp;
        } catch (Exception) {
            Console.WriteLine(e);
        }
    }
}
