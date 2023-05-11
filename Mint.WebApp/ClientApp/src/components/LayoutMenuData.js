import React, { useCallback, useMemo, useState } from "react";
import { useSelector } from "react-redux";

const Navdata = () => {
  const { menu } = useSelector((state) => ({
    menu: state.Categories.menu,
  }));

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

  const menuItems = useMemo(() => {
    const items = [];
    menu.map((item) => {
      const data = {
        id: item.id,
        label: item.parentName,
        icon: item.parentIco,
        link: "/#",
        orderBy: item.parentOrder,
        badgeText: item.parentBadgeText,
        badgeStyle: item.parentBadgeStyle,
        click: function (e) {
          e.preventDefault();
          updateIconSidebar(e);
        },
      };

      item.menuChildViewModels.map((childItem) => {
        if (!data.subItems) data.subItems = [];

        data.subItems.push({
          id: childItem.id,
          label: childItem.childName,
          link: "/categories/" + childItem.link,
          parentId: item.id,
        });
      });
      items.push(data);
    });
    return items;
  }, [menu]);

  return <React.Fragment>{menuItems}</React.Fragment>;
};
export default Navdata;
