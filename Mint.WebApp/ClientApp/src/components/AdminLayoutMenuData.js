import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Roles } from "../constants/Roles";

const AdminNavdata = () => {
  const history = useNavigate();
  const [iscurrentState, setIscurrentState] = useState("Dashboard");
  const [isDashboard, setIsDashboard] = useState(false);
  const [isCatalog, setIsCatalog] = useState(false);
  const [isSales, setIsSales] = useState(false);
  const [isNews, setIsNews] = useState(false);
  const [isCustomer, setIsCustomer] = useState(false);
  const [isSeller, setIsSeller] = useState(false);

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

  useEffect(() => {
    document.body.classList.remove("twocolumn-panel");
    if (iscurrentState === "Dashboard") {
      history("/admin/admin-dashboard");
      document.body.classList.add("twocolumn-panel");
    }
    if (iscurrentState === "Widgets") {
      history("/widgets");
      document.body.classList.add("twocolumn-panel");
    }
    if (iscurrentState !== "Dashboard") {
      setIsDashboard(false);
    }
    if (iscurrentState !== "Catalog") {
      setIsCatalog(false);
    }
    if (iscurrentState !== "Sales") {
      setIsSales(false);
    }
    if (iscurrentState !== "News") {
      setIsNews(false);
    }
    if (iscurrentState !== "Customer") {
      setIsCustomer(false);
    }
    if (iscurrentState !== "Seller") {
      setIsSeller(false);
    }
  }, [
    history,
    iscurrentState,
    isCatalog,
    isSales,
    isNews,
    isSeller,
    isCustomer,
  ]);

  const menuItems = [
    {
      label: "Меню",
      isHeader: true,
    },
    {
      id: "dashboard",
      label: "Дашбоард",
      icon: "ri-dashboard-2-line",
      link: "/admin/admin-dashboard",
      stateVariables: isDashboard,
      click: function (e) {
        e.preventDefault();
        setIsDashboard(!isDashboard);
        setIscurrentState("Dashboard");
      },
    },
    {
      label: "Администрирование",
      isHeader: true,
    },
    {
      id: "catalog",
      label: "Каталог",
      icon: "ri-article-line",
      link: "/#",
      click: function (e) {
        e.preventDefault();
        setIsCatalog(!isCatalog);
        setIscurrentState("Catalog");
        updateIconSidebar(e);
      },
      stateVariables: isCatalog,
      subItems: [
        {
          id: "categories",
          label: "Категории",
          link: "/admin/categories",
          parentId: "catalog",
        },
        {
          id: "products",
          label: "Управление продуктами",
          link: "/admin/products",
          parentId: "catalog",
        },
        {
          id: "products_review",
          label: "Обзоры продуктов",
          link: "/admin/products-review",
          parentId: "catalog",
        },
        {
          id: "manufactures",
          label: "Производители",
          link: "/admin/manufactures",
          parentId: "catalog",
        },
      ],
    },
    {
      id: "sales",
      label: "Продажи",
      icon: "ri-pie-chart-line",
      link: "/#",
      click: function (e) {
        e.preventDefault();
        setIsSales(!isSales);
        setIscurrentState("Sales");
        updateIconSidebar(e);
      },
      stateVariables: isSales,
      subItems: [
        {
          id: "orders",
          label: "Заказы",
          link: "/admin/orders",
          parentId: "sales",
        },
        {
          id: "shipments",
          label: "Отгрузки",
          link: "/admin/shipments",
          parentId: "sales",
        },
      ],
    },
    {
      id: "news",
      label: "Новости",
      icon: "ri-newspaper-line",
      link: "/#",
      roles: [Roles.Admin],
      click: function (e) {
        e.preventDefault();
        setIsNews(!isNews);
        setIscurrentState("News");
        updateIconSidebar(e);
      },
      stateVariables: isNews,
      subItems: [
        {
          id: "banners",
          label: "Банеры",
          link: "/admin/news/banners",
          parentId: "news",
        },
        {
          id: "promotions",
          label: "Акции",
          link: "/admin/news/promotions",
          parentId: "news",
        },
      ],
    },
    {
      label: "Пользователи",
      isHeader: true,
      roles: [Roles.Admin],
    },
    {
      id: "customers",
      label: "Сотрудники",
      icon: "ri-customer-service-line",
      link: "/#",
      roles: [Roles.Admin],
      click: function (e) {
        e.preventDefault();
        setIsCustomer(!isCustomer);
        setIscurrentState("Customer");
        updateIconSidebar(e);
      },
      stateVariables: isCustomer,
      subItems: [
        {
          id: "test",
          label: "test",
          link: "/admin/news/banners",
          parentId: "customers",
        },
      ],
    },
    {
      id: "sellers",
      label: "Продавцы",
      icon: "ri-file-user-line",
      link: "/#",
      roles: [Roles.Admin],
      click: function (e) {
        e.preventDefault();
        setIsSeller(!isSeller);
        setIscurrentState("Seller");
        updateIconSidebar(e);
      },
      stateVariables: isSeller,
      subItems: [
        {
          id: "test",
          label: "test",
          link: "/admin/news/banners",
          parentId: "sellers",
        },
      ],
    },
    {
      id: "widgets",
      label: "Widgets",
      icon: "ri-honour-line",
      link: "/widgets",
      click: function (e) {
        e.preventDefault();
        setIscurrentState("Widgets");
      },
    },
  ];
  return <React.Fragment>{menuItems}</React.Fragment>;
};
export default AdminNavdata;
