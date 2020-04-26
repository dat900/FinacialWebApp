function updateChart(chart, urlString) {
	$.ajax({
		url: urlString,
		method: 'POST',
		data: {},
		async: true,
		success: function (data) {
			chart.data.labels = data.labels;
			chart.data.datasets[0].data = data.money;
			chart.update();
		}
	});
}
