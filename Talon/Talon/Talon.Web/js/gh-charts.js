


	var chart1width = jQuery('#mainGraphProjects').parent().width();
	var chart1height = Math.floor(jQuery('#mainGraphProjects').parent().width() * .4);
	var chart1data = 
	{
	  workload:       [8, 10,  6, 12,  7, 6, 9],
	  your_workload:  [6,  8,  4,  8, 12, 6, 2],
	  his_workload:   [2,  9, 12,  7,  8, 9, 8]
	};
	var chart1params = 
	{
	  width:                    chart1width,
	  height:					chart1height,
	  background_color:         "#F2d89C",
	  markers :                 "value",
	  grid :                    true,
	  grid_color :              "#e5bd58",
	  draw_axis :               false,
	  plot_padding :            0,
	  stroke_width :            0,
	  show_vertical_labels :    false,
	  show_horizontal_labels :  false,
	  hover_color :             "#000",
	  hover_text_color :        "#fff",
	  colors :                { 
	  	workload: '#e5bd58',
	  	your_workload: '#e5bd58',
	  	his_workload: '#e5bd58', 
	  },
	  datalabels : {
	    workload:       "My workload",
	    your_workload:  "Your workload",
	    his_workload:   "His workload"
	  }
	};
	var chartgraph1 = new Grafico.AreaGraph($('mainGraphProjects'),chart1data, chart1params);


	var chart2width = jQuery('#mainGraphQuarters').parent().width();
	var chart2height = Math.floor(jQuery('#mainGraphQuarters').parent().width() * .4);
	var chart2data = 
	{
	  workload:       [8, 10,  6, 12,  7, 6, 9],
	  your_workload:  [6,  8,  4,  8, 12, 6, 2],
	  his_workload:   [2,  9, 12,  7,  8, 9, 8]
	};
	var chart2params = 
	{
	  width:                    chart2width,
	  height:					chart2height,
	  background_color:         "#F2d89C",
	  markers :                 "value",
	  grid :                    true,
	  grid_color :              "#e5bd58",
	  draw_axis :               false,
	  plot_padding :            0,
	  stroke_width :            0,
	  show_vertical_labels :    false,
	  show_horizontal_labels :  false,
	  hover_color :             "#000",
	  hover_text_color :        "#fff",
	  colors :                { 
	  	workload: '#e5bd58',
	  	your_workload: '#e5bd58',
	  	his_workload: '#e5bd58', 
	  },
	  datalabels : {
	    workload:       "My workload",
	    your_workload:  "Your workload",
	    his_workload:   "His workload"
	  }
	};
	var chartgraph2 = new Grafico.AreaGraph($('mainGraphQuarters'),chart2data, chart2params);

	var chart3width = jQuery('#mainGraphPercentage').parent().width();
	var chart3height = Math.floor(jQuery('#mainGraphPercentage').parent().width() * .4);
	var chart3data = 
	{
	  workload:       [8, 10,  6, 12,  7, 6, 9],
	  your_workload:  [6,  8,  4,  8, 12, 6, 2],
	  his_workload:   [2,  9, 12,  7,  8, 9, 8]
	};
	var chart3params = 
	{
	  width:                    chart3width,
	  height:					chart3height,
	  background_color:         "#F2d89C",
	  markers :                 "value",
	  grid :                    true,
	  grid_color :              "#e5bd58",
	  draw_axis :               false,
	  plot_padding :            0,
	  stroke_width :            0,
	  show_vertical_labels :    false,
	  show_horizontal_labels :  false,
	  hover_color :             "#000",
	  hover_text_color :        "#fff",
	  colors :                { 
	  	workload: '#e5bd58',
	  	your_workload: '#e5bd58',
	  	his_workload: '#e5bd58', 
	  },
	  datalabels : {
	    workload:       "My workload",
	    your_workload:  "Your workload",
	    his_workload:   "His workload"
	  }
	};
	var chartgraph2 = new Grafico.AreaGraph($('mainGraphPercentage'),chart3data, chart3params);





    var delay = (function() {
        var timer = 0;
        return function(callback, ms) {
            clearTimeout(timer);
            timer = setTimeout(callback, ms);
        };
    })();

    jQuery(window).resize(function() {
    	delay(function() {
    		chart1width = jQuery('#mainGraphProjects').parent().width();
			chart1height = Math.floor(jQuery('#mainGraphProjects').parent().width() * .4);
        	areagraph4.initialize(chart1data, chart1params);
        }, 100);
    }).trigger('resize');


