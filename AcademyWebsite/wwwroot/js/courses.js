// Function to format countdown timers
function formatTime(ms) {
    var d = Math.floor(ms / (1000 * 60 * 60 * 24));
    var h = Math.floor((ms % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var m = Math.floor((ms % (1000 * 60 * 60)) / (1000 * 60));
    var s = Math.floor((ms % (1000 * 60)) / 1000);
    return d + 'd ' + h + 'h ' + m + 'm ' + s + 's';
}

// Function to update course timers
function updateCourseTimers() {
    var courses = document.querySelectorAll('.course-timer');
    courses.forEach(function (course) {
        var startDate = new Date(course.getAttribute('data-start'));
        var endDate = new Date(course.getAttribute('data-end'));
        var now = new Date();

        var timeToStart = startDate - now;
        var timeToEnd = endDate - now;

        if (timeToStart > 0) {
            course.innerHTML = 'Starts in: ' + formatTime(timeToStart);
            course.style.color = 'green';
        } else if (timeToEnd > 0) {
            course.innerHTML = 'Ongoing, ends in: ' + formatTime(timeToEnd);
            course.style.color = 'orange';
        } else {
            course.innerHTML = 'Course ended.';
            course.style.color = 'red';
        }
    });
}

// Update timers every second
setInterval(updateCourseTimers, 1000);
updateCourseTimers();

// Filtering and sorting logic
document.getElementById('searchInput').addEventListener('input', filterCourses);
document.getElementById('categoryFilter').addEventListener('change', filterCourses);
document.getElementById('sortPrice').addEventListener('change', sortCourses);

function filterCourses() {
    var searchText = document.getElementById('searchInput').value.toLowerCase();
    var selectedCategory = document.getElementById('categoryFilter').value.toLowerCase();
    var courses = document.querySelectorAll('.course-card');

    courses.forEach(function (course) {
        var name = course.getAttribute('data-name');
        var category = course.getAttribute('data-category');

        var matchesSearch = name.includes(searchText);
        var matchesCategory = selectedCategory === "" || category === selectedCategory;

        course.style.display = (matchesSearch && matchesCategory) ? "block" : "none";
    });

    sortCourses(); // Sort after filtering
}

function sortCourses() {
    var sortValue = document.getElementById('sortPrice').value;
    var container = document.getElementById('courseContainer');
    var courses = Array.from(document.querySelectorAll('.course-card')).filter(course => course.style.display !== "none");

    if (sortValue === "asc") {
        courses.sort((a, b) => parseFloat(a.getAttribute('data-price')) - parseFloat(b.getAttribute('data-price')));
    } else if (sortValue === "desc") {
        courses.sort((a, b) => parseFloat(b.getAttribute('data-price')) - parseFloat(a.getAttribute('data-price')));
    }

    courses.forEach(course => container.appendChild(course));
}
