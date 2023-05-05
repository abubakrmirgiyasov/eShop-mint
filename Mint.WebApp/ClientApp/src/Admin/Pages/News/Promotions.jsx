import React, { useCallback, useEffect, useState } from "react";
import { Button, Card, CardBody, CardHeader, Col, Row } from "reactstrap";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";
import PromotionsTable from "../../components/Tables/PromotionsTable";
import PromotionsAction from "./PromotionsAction";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import PromotionDelete from "./PromotionDelete";

const Promotions = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [isEdit, setIsEdit] = useState(false);
  const [isDelete, setIsDelete] = useState(false);
  const [data, setData] = useState([]);
  const [updateData, setUpdateData] = useState(null);
  const [deleteId, setDeleteId] = useState(null);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/discount/getpromotions")
      .then((response) => {
        setIsLoading(false);
        setData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const actionToggle = useCallback(() => {
    if (isEdit) {
      setIsEdit(false);
    } else {
      setIsEdit(true);
    }
  }, [isEdit]);

  const deleteToggle = useCallback(() => {
    if (isDelete) {
      setIsDelete(false);
    } else {
      setIsDelete(true);
    }
  }, [isDelete]);

  const handleAddClick = () => {
    setUpdateData(null);
    setIsEdit(false);
    actionToggle();
  };

  function handleNewData(newData) {
    setData([...data, newData]);
  }

  function handleUpdateData(updateData) {
    setUpdateData(updateData);
    setIsEdit(false);
    actionToggle();
  }

  function handleRemoveData(removeData) {
    setDeleteId(removeData);
    setIsDelete(true);
    deleteToggle();
  }

  function updateItem(newItem) {
    let item = [...data];
    const temp = item.findIndex((x) => x.id === newItem.id);
    const discount = { ...item[temp] };
    discount.name = newItem.name;
    discount.activeDateUntil = newItem.activeDateUntil;
    discount.percent = newItem.percent;
    item[temp] = discount;
    setData(item);
  }

  function removeItem(id) {
    const newData = data.filter((x) => x.id !== id);
    setData(newData);
  }

  return (
    <div className={"page-content"}>
      {error ? <Error message={error} /> : null}
      <Card>
        <CardHeader>
          <h2>Акции</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
            <div className={"d-flex justify-content-center"}>
              <div className={"spinner-border text-success"} role={"status"}>
                <span className={"sr-only"}>Loading...</span>
              </div>
            </div>
          ) : (
            <Row>
              <Col lg={12}>
                <div className={"d-flex align-items-center"}>
                  <PrivateComponent>
                    <Button
                      className={"fs-14 btn btn-success"}
                      roles={[Roles.Admin, Roles.Seller]}
                      onClick={handleAddClick}
                    >
                      <i className="ri-add-line align-middle"></i> Добавить
                      новое ...
                    </Button>
                  </PrivateComponent>
                </div>
              </Col>
              <Col lg={12}>
                <PromotionsTable
                  data={data || []}
                  updateData={handleUpdateData}
                  removeData={handleRemoveData}
                />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
      <PromotionsAction
        isOpen={isEdit}
        toggle={actionToggle}
        newData={handleNewData}
        updatedData={updateData}
        dataForUpdate={updateItem}
      />
      <PromotionDelete
        id={deleteId}
        isOpen={isDelete}
        toggle={deleteToggle}
        removeData={removeItem}
      />
    </div>
  );
};

export default Promotions;
