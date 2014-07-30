// JavaScript Document


$(function(){
                
                add_line(
                        $(this).position().left + ($(this).outerWidth(true)/2),
                        $(this).position().top + ($(this).outerHeight(true)/2),
                        last_clicked.position().left + (last_clicked.outerWidth(true)/2), 
                        last_clicked.position().top + (last_clicked.outerHeight(true)/2)
                        );
            
    

    
    var ctx = document.getElementById("background").getContext("2d");
    var lines = [];
    
    function draw_loop()
    {
        ctx.fillStyle="#fff";
        //Clear the background
        ctx.fillRect(0,0,7000,7000);
        
        for(var i in lines)
        {
//Draw each line in the draw buffer            
            ctx.beginPath();
            ctx.lineWidth = Math.floor((1+Math.random() * 10));
            ctx.strokeStyle = lines[i].color;
            ctx.moveTo(lines[i].start.x, lines[i].start.y);
            ctx.lineTo(lines[i].end.x, lines[i].end.y);
            ctx.stroke();
        }        
        setTimeout(draw_loop, 25/1000);
         console.log(lines);
    }
    //Run the draw_loop for the first time. It will call itself 25 times per second after that    
    draw_loop();
    
    //Adds a line in the drawing loop of the background canvas
    function add_line(start_x, start_y, end_x, end_y, color)
    {
        lines.push({
            start:{
                x: start_x,
                y: start_y
            },
            end:{
                x: end_x,
                y: end_y
            },
            'color': color?color:"#"+("000"+(Math.random()*(1<<24)|0).toString(16)).substr(-6)
        });
    }
});

