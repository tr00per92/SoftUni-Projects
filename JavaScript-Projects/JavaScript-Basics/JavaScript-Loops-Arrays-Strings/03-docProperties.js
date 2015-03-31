function displayProperties(input) {
	var result = [];
	for (var property in input) {
		result.push(property);
	}
	result.sort();
	return result;
}
// run through browser console
console.log(displayProperties(document).join("\n"));