import React, { ReactNode, useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { IAuth } from "../../../services/types/IAuth";
import AdminHeader from "../Header/Header";
import AdminSidebar from "../Header/Sidebar";
import { switchLayout } from "../../../store/theme/theme";
import { Button } from "reactstrap";
import { ToastContainer } from "react-toastify";

const AdminLayout = ({ children }: ReactNode) => {
  const [headerClass, setHeaderClass] = useState<string>("");

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { auth }: { auth: IAuth } = useSelector((state) => ({
    auth: state.Auth,
  }));

  useEffect(() => {
    dispatch(switchLayout("vertical"));
    // dispatch(myStore(fetch))
  }, [dispatch, auth]);

  useEffect(() => {
    window.addEventListener("scroll", scrollNavigation, true);
  });

  function scrollNavigation() {
    setHeaderClass(document.documentElement.scrollTop > 50 ? "top-shadow" : "");
  }

  window.onscroll = function () {
    const element = document.getElementById("back-to-top");

    if (element) {
      if (
        document.body.scrollTop > 100 ||
        document.documentElement.scrollTop > 100
      ) {
        element.style.display = "block";
      } else {
        element.style.display = "none";
      }
    }
  };

  const toTop = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
  };

  return (
    <React.Fragment>
      <div id={"layout-wrapper"}>
        <AdminHeader headerClass={headerClass} />
        <AdminSidebar />
        <div className={"main-content"}>{children}</div>
        <Button
          type={"button"}
          onClick={toTop}
          className={"btn-icon landing-back-top"}
          color={"success"}
          id={"back-to-top"}
        >
          <i className="ri-arrow-up-line"></i>
        </Button>
      </div>
      <ToastContainer
        position={"top-right"}
        autoClose={5000}
        limit={10}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick={true}
        rtl={false}
        pauseOnFocusLoss={true}
        draggable={true}
        pauseOnHover={true}
        theme={"colored"}
      />
    </React.Fragment>
  );
};

export default AdminLayout;
