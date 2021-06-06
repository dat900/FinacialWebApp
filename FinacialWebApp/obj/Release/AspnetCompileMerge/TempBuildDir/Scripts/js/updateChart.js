function updateChart(chart, urlString, type_money) {
	chart.destroy();
	$.ajax({
		url: urlString,
		method: 'POST',		
		async: true,
		success: function (data) {
			chart.labels = data.labels;
			chart.data.datasets[0].data = data.money;
			chart.data.datasets[0].label = type_money;
			chart.update();
		}
	});
}
