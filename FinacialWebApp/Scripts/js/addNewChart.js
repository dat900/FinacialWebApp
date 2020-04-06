function addNewChart(container, labels, type_money, data, type, backgroundColor, pointColor) {
	var options = {
		type: type,
		data: {
			labels: labels,
			datasets: [
				{
					label: type_money,
					data: data,
					borderWidth: 1,
					pointRadius: 2,
					pointBackgroundColor: backgroundColor,
					backgroundColor: pointColor
				}
			]
		}
	};
	new Chart(container, options);
}
