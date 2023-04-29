import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useSelector } from "react-redux";

const Navdata = () => {
  const { menu } = useSelector((state) => ({
    menu: state.Categories.menu,
  }));

  const [isDashboard, setIsDashboard] = useState(false);

  function updateIconSidebar(e) {
    if (e && e.target && e.target.getAttribute("subitems")) {
      const ul = document.getElementById("two-column-menu");
      const iconItems = ul.querySelectorAll(".nav-icon.active");
      let activeIconItems = [...iconItems];
      activeIconItems.forEach((item) => {
        item.classList.remove("active");
        const id = item.getAttribute("subitems");
        if (document.getElementById(id))
          document.getElementById(id).classList.remove("show");
      });
    }
  }
  console.log(menu);
  const menuItems = [];

  menu.map((item) => {
    const data = {
      id: item.id,
      label: item.parentName,
      icon: item.parentIco,
      link: "/#",
      orderBy: item.parentOrder,
      badgeText: item.parentBadgeText,
      badgeStyle: item.parentBadgeStyle,
      stateVariables: isDashboard,
      click: function (e) {
        e.preventDefault();
        setIsDashboard(!isDashboard);
        updateIconSidebar(e);
      },
    };

    item.menuChildViewModels.map((childItem) => {
      if (!data.subItems) data.subItems = [];

      data.subItems.push({
        id: childItem.id,
        label: childItem.childName,
        link: childItem.childLink,
        parentId: item.id,
      });
    });
    menuItems.push(data);
  });

  return <React.Fragment>{menuItems}</React.Fragment>;
};
export default Navdata;
