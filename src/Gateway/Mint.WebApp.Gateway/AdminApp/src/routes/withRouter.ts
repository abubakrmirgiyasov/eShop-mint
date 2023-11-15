import {Location, NavigateFunction, ParamMap, useLocation, useNavigate, useParams,} from "react-router-dom";
import {FC} from "react";

interface IRouterProps {
    location: Location,
    navigate: NavigateFunction,
    params: ParamMap,
}

interface IWithRouterProps {
    router: IRouterProps;
}

type WrappedComponentProps = IWithRouterProps & {};

// function withRouter<P extends WrappedComponentProps>(
//     Component: React.ComponentType<P>
// ): React.FC<Omit<P, "router">> {
//     const ComponentWithRouterProp: React.FC<Omit<P, "router">> = (props) => {
//         const location = useLocation();
//         const navigate = useNavigate();
//         const params = useParams();
//
//         const routerProps: RouterProps = { location, navigate, params };
//
//         return <Component {...props as P} router={routerProps} />;
//     };
//
//     return ComponentWithRouterProp;
// }
//
// export default withRouter;