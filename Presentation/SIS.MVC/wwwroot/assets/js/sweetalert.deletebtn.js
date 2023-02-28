let btns = document.querySelectorAll("#deletebtn");

btns.forEach(x => {
	let url = x.getAttribute("href");
	x.addEventListener("click", function (e) {
		e.preventDefault();

		Swal.fire({
			title: 'Are you sure?',
			icon: 'warning',
			showCancelButton: true,
			confirmButtonColor: '#3085d6',
			cancelButtonColor: '#d33',
			confirmButtonText: 'Yes, delete it!'
		}).then((result) => {
			if (result.isConfirmed) {

				fetch(url).then(
					response => {
						if (response.status == 200) {
							x.parentElement.parentElement.parentElement.remove();

							Swal.fire(
								'Deleted!',
								'Element has been deleted.',
								'success'
							);
						}
						else {
							Swal.fire({
								icon: 'error',
								title: 'Couldn\'t delete!',
								text: 'Something went wrong!'
							})
						}
					}
				);


			}
		})

	});

});