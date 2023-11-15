export default function adaptiveMenu() {
    let windowSize = document.documentElement.clientWidth;

    if (windowSize > 767)
        document.querySelector(".hamburger-icon").classList.toggle("open");

    if (document.documentElement.getAttribute("data-layout") === "horizontal")
        document.body.classList.contains("menu")
            ? document.body.classList.remove("menu")
            : document.body.classList.add("menu");

    if (document.documentElement.getAttribute("data-layout") === "vertical") {
        if (windowSize < 1025 && windowSize > 767) {
            document.body.classList.remove("vertical-sidebar-enable");
            document.documentElement.getAttribute("data-sidebar-size") === "sm"
                ? document.documentElement.setAttribute("data-sidebar-size", "")
                : document.documentElement.setAttribute("data-sidebar-size", "sm");
        } else if (windowSize > 1025) {
            document.body.classList.remove("vertical-sidebar-enable");
            document.documentElement.getAttribute("data-sidebar-size") === "lg"
                ? document.documentElement.setAttribute("data-sidebar-size", "sm")
                : document.documentElement.setAttribute("data-sidebar-size", "lg");
        } else if (windowSize <= 767) {
            document.body.classList.add("vertical-sidebar-enable");
            document.documentElement.setAttribute("data-sidebar-size", "lg");
        }
    }
}