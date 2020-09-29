const cp = require("child_process").execFile;
const child=cp(__dirname+"/runproc",['s,C:\\wamp\\bin\\php\\php5.6.25\\php-cgi.exe,127.0.0.1:9000'],(error,stdout,stderr)=>{
    if(error){
        console.log('stderr',stderr);
        throw error;
    }
    console.log('stdout',stdout);
});