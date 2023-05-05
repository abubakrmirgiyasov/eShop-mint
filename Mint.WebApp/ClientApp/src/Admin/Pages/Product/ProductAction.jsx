import React, { useEffect, useMemo, useState } from "react";
import {
  Card,
  CardBody,
  CardHeader,
  Col,
  Container,
  Row,
  TabContent,
} from "reactstrap";
import { Error } from "../../../components/Notification/Error";
import { Link, useParams } from "react-router-dom";
import Breadcrumb from "../../../components/Breadcrumb/Breadcrumb";
import classnames from "classnames";
import Info from "./ProductAction/Info";
import Characteristics from "./ProductAction/Characteristics";
import Price from "./ProductAction/Price";
import Pictures from "./ProductAction/Pictures";
import CategoryMappings from "./ProductAction/CategoryMappings";
import ManufactureMappings from "./ProductAction/ManufactureMappings";
import Promotions from "./ProductAction/Promotions";
import { fetchWrapper } from "../../../helpers/fetchWrapper";

const ProductAction = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [activeTab, setActiveTab] = useState(1);
  const [addingData, setAddingData] = useState(false);
  const [dataForUpdate, setDataForUpdate] = useState([]);

  const params = useParams();

  useEffect(() => {
    if (params.id) {
      setIsLoading(true);

      fetchWrapper
        .get("api/product/getproductbyid/" + params.id)
        .then((response) => {
          setIsLoading(false);
          setDataForUpdate(response);
          setAddingData(true);
        })
        .catch((error) => {
          setError(error);
          setIsLoading(false);
        });
    }
  }, [params]);

  const tabChangeToggle = (tab) => {
    if (activeTab !== tab) setActiveTab(tab);
  };

  function handleAddingData(value) {
    setAddingData(value);
  }

  return (
    <div className="page-content">
      <Container fluid={true}>
        {error ? <Error mesage={error} /> : null}
        <Breadcrumb
          title={!params.id ? "Добавить новый продукт" : "Изменить продукт"}
          pageTitle={"Продукты"}
          link={"/admin/products"}
        />
        <Card>
          <CardHeader>
            <h3 className={"fs-20 fw-bold"}>
              <Link to={"/admin/products"} className={"btn btn-light"}>
                <i className={"ri-arrow-left-line"}></i>
              </Link>{" "}
              {!params.id ? "Добавить новый продукт" : "Изменить продукт"}
            </h3>
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
                <Col lg={12} className={"mb-3"}>
                  <ul
                    className={
                      "nav nav-tabs nav-justified nav-border-top nav-border-top-success mb-3 nav nav-tabs"
                    }
                  >
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(1)}
                        className={classnames(
                          { active: activeTab === 1 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-pencil-line"}></i> Информация
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(7)}
                        className={classnames(
                          { active: activeTab === 7 },
                          "nav-link fs-14 cursor-pointer"
                        )}
                      >
                        <i className={"ri-file-list-3-line"}></i> Характеристики
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(2)}
                        className={classnames(
                          { active: activeTab === 2 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-vip-diamond-line"}></i> Цена
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(3)}
                        className={classnames(
                          { active: activeTab === 3 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-camera-line"}></i> Картинки
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(4)}
                        className={classnames(
                          { active: activeTab === 4 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-git-merge-line"}></i> Категории
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(5)}
                        className={classnames(
                          { active: activeTab === 5 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-building-4-line"}></i> Производители
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        onClick={() => tabChangeToggle(6)}
                        className={classnames(
                          { active: activeTab === 6 },
                          "nav-link fs-16 cursor-pointer"
                        )}
                      >
                        <i className={"ri-hand-heart-line"}></i> Скидки
                      </a>
                    </li>
                  </ul>
                </Col>
                <Col lg={12}>
                  <TabContent activeTab={activeTab}>
                    <Info
                      setAddingData={handleAddingData}
                      dataForUpdate={dataForUpdate}
                    />
                    <Characteristics
                      isAdded={addingData}
                      dataForUpdate={dataForUpdate}
                    />
                    <Price isAdded={addingData} dataForUpdate={dataForUpdate} />
                    <Pictures
                      isAdded={addingData}
                      dataForUpdate={dataForUpdate}
                    />
                    <CategoryMappings
                      isAdded={addingData}
                      dataForUpdate={dataForUpdate}
                    />
                    <ManufactureMappings
                      isAdded={addingData}
                      dataForUpdate={dataForUpdate}
                    />
                    <Promotions
                      isAdded={addingData}
                      dataForUpdate={dataForUpdate}
                    />
                  </TabContent>
                </Col>
              </Row>
            )}
          </CardBody>
        </Card>
      </Container>
    </div>
  );
};

export default ProductAction;
