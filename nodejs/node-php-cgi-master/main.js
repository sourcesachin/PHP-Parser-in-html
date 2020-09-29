reqdata = require("url").parse(req.url,true);
switch(require("path").extname(reqdata.pathname)) {
    case ".php":
            var phpCGI = require("php-cgi");
            phpCGI.detectBinary();//on windows get a portable php to run.
            phpCGI.env['DOCUMENT_ROOT'] = __dirname+path.sep+'htdocs'+path.sep;
            phpCGI.serveResponse(req, res, phpCGI.paramsForRequest(req));
        break;
}