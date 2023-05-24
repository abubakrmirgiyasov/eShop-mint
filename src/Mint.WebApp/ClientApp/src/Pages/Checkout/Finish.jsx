import React, { useState } from "react";
import { Button, TabPane } from "reactstrap";
import { Error } from "../../components/Notification/Error";
import { Success } from "../../components/Notification/Success";
import { Link } from "react-router-dom";

const Finish = ({ newOrder }) => {
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      {success ? <Success message={success} /> : null}
      <TabPane tabId={6}>
        <div className={"text-center"}>
          <div className={"mb-4"}>
            <lord-icon
              src={"https://cdn.lordicon.com/lupuorrc.json"}
              trigger={"loop"}
              colors={"primary:#0ab39c,secondary:#405189"}
              style={{ width: "120px", height: "120px" }}
            ></lord-icon>
          </div>
          <h5>Заказ принят!</h5>
          <p className="text-muted">
            Заказ в обработке, подробности можете посмотреть по{" "}
            <Link to={"/orders/details/" + newOrder?.id} color={"primary"}>
              ссылке
            </Link>
          </p>
        </div>
        <Link
          className={"btn btn-success me-2"}
          color={"success"}
          to={"/orders/details/" + newOrder?.id}
        >
          Подробности
        </Link>
        <Link to={"/"} className={"btn btn-outline-success"}>
          Продолжить покупки
        </Link>
      </TabPane>
    </React.Fragment>
  );
};

export default Finish;
