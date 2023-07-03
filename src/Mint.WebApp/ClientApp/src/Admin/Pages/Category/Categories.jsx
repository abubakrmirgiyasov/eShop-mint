import React, { useCallback, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
  Button,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  Input,
  Label,
  Row,
  Spinner,
} from "reactstrap";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import DeleteCategory from "./DeleteCategory";
import PrivateComponent from "../../../helpers/privateComponent";
import { Roles } from "../../../constants/Roles";

//import CategoriesGridTable from "../../components/Tables/Grid/CategoriesGridTable";
import CategoriesTable from "../../components/Tables/CategoriesTable";

const Categories = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [isFilterOpen, setIsFilterOpen] = useState(false);
  const [error, setError] = useState(null);
  const [itemId, setItemId] = useState(null);
  const [data, setData] = useState([]);
  const [isDelete, setIsDelete] = useState(false);

  useEffect((response) => {
    setIsLoading(true);
    fetchWrapper
      .get("api/category/getcategories")
      .then((response) => {
        setIsLoading(false);
        setData(response);
      })
      .catch((error) => {
        setIsLoading(false);
        setError(error);
      });
  }, []);

  const toggle = useCallback(() => {
    if (isDelete) {
      setIsDelete(false);
    } else {
      setIsDelete(true);
    }
  }, [isDelete]);

  const handleFilterClick = () => {
    setIsFilterOpen(!isFilterOpen);
  };

  function handleDeleteClick(item) {
    setItemId(item.id);
    setIsDelete(true);
  }

  function removeData(id) {
    const categories = data.filter((x) => x.id !== id);
    setData(categories);
  }

  return (
    <div className="page-content">
      {error ? <Error message={error} /> : null}
      <Card>
        <CardHeader>
          <h2>Управление категориями</h2>
        </CardHeader>
        <CardBody>
          <Row>
            <Col lg={12}>
              <div className="d-flex align-items-center">
                <Button
                  className="me-2 fs-14"
                  color="primary"
                  onClick={handleFilterClick}
                >
                  <i className="ri-filter-2-line"></i>
                </Button>
                <PrivateComponent>
                  <Link
                    to="/admin/categories/add"
                    className="fs-14 btn btn-success"
                    roles={[Roles.Admin]}
                  >
                    <i className="ri-add-line align-middle"></i> Добавить новое
                    ...
                  </Link>
                </PrivateComponent>
              </div>
              <Collapse isOpen={isFilterOpen}>
                <div className={"d-flex mt-3"}>
                  <Input
                    type={"text"}
                    className={"w-25 me-3"}
                    placeholder={"Поиск по названию"}
                  />
                  <Input
                    type={"checkbox"}
                    id={"resizable"}
                    className={"form-check-input"}
                    color={"success"}
                  />
                  <Label htmlFor={"resizable"}>Изменяемый</Label>
                </div>
              </Collapse>
            </Col>
            <Col lg={12}>
              {isLoading ? (
                <div
                  className={"d-flex justify-content-center align-items-center"}
                >
                  <Spinner color={"success"} size={"sm"}>
                    Loading...
                  </Spinner>
                </div>
              ) : (
                <CategoriesTable
                  data={data}
                  handleDeleteClick={handleDeleteClick}
                />
              )}
            </Col>
          </Row>
        </CardBody>
      </Card>
      <DeleteCategory
        isOpen={isDelete}
        toggle={toggle}
        itemId={itemId}
        removeData={removeData}
      />
    </div>
  );
};

export default Categories;
