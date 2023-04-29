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
  Row,
} from "reactstrap";
import CategoriesTable from "../../components/Tables/CategoriesTable";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import DeleteCategory from "./DeleteCategory";

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
                <Link
                  to="/admin/categories/add"
                  className="fs-14 btn btn-success"
                >
                  <i className="ri-add-line align-middle"></i> Добавить новое
                  ...
                </Link>
              </div>
              <Collapse isOpen={isFilterOpen} horizontal={true}>
                <div className="d-flex mt-3">
                  <Input
                    type="text"
                    className="w-25 me-3"
                    placeholder="Поиск по названию"
                  />
                  <Button color="danger">
                    <i className="ri-search-2-line"></i>
                  </Button>
                </div>
              </Collapse>
            </Col>
            <Col lg={12}>
              {isLoading ? (
                <div
                  className={"d-flex justify-content-center align-items-center"}
                >
                  <div className={"spinner-grow text-success"} role={"status"}>
                    <span className={"visually-hidden"}>Loading...</span>
                  </div>
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
