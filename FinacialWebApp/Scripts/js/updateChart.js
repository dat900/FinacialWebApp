function updateChart(chart, urlString) {
	$.ajax({
		url: urlString,
		method: 'POST',
		data: {},
		async: true,
		success: function (data) {
			chart.options = {
				data: {
					labels: data.labels,
					datasets: [
						{
							data: data.money,
						}
					]
				}
			};
			chart.update();
		}
	});
}
