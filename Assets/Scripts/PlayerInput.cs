// GENERATED AUTOMATICALLY FROM 'Assets/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Normal (No Powerups)"",
            ""id"": ""e80d9827-37d0-4cfe-8d0e-7c8a44979d36"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""da9c83ad-fe07-465c-ab2d-6389ee7fdba4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8ae8bd6c-cbbf-4732-9fd1-4df2c6e7f7a4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""71fcf06e-a441-4356-a627-ab2f80d67e97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""19191325-5ef5-4719-96bc-0b90019f8443"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4e0ddb5-198f-48a4-bba9-778fa01394ef"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""29da982e-119f-41b6-ba5e-393686ab824e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a64f54fe-fd3a-48dc-8a04-1fcb2512e602"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""39fd0459-ee19-40dc-aadd-c33579eb7b5f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e0d33b20-a662-495f-89ee-5e6889e6260b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6f0321df-6e40-4807-b17c-069d2ae4947c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""LazerMode"",
            ""id"": ""56f4de7e-ec25-4457-acca-6b102d723906"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9e29f003-3874-4d76-b36b-66cb5c0ea2d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3f85a525-aa1e-4321-be3c-cb19d0e27370"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""49493623-8ec4-4ba0-80ac-6718c27ba8cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lazer"",
                    ""type"": ""Value"",
                    ""id"": ""76e4e8e9-5a80-4a68-b3f8-0993c2187141"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""64b1a6cf-3d23-4194-83c1-8f53bfba3132"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d41fbf79-5301-417e-845e-55ed0382b519"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4ea312c7-4ac9-4fad-92e1-bbfc6c2c01e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d64233bf-6c6e-4667-a388-03c78be09ba2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eaeb23f7-3eec-4d5a-b14a-e3564bd69a7a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2abf4409-fa75-41fb-89ce-9c9bf4a42ad8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""280d0238-a67f-4847-bcb9-613359177921"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5465606d-dc04-40bc-816c-549bf525f35d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lazer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""TeleportMode"",
            ""id"": ""4a35e145-3d15-459f-8a14-f5033d8b947a"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""701e9672-c03a-4d82-ad8e-22e24798ec8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d4bccebc-5b8b-4996-b1ad-315420e16621"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""7feba440-b8d1-42a1-9200-c17b52ed58e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""Button"",
                    ""id"": ""f47852a8-ad5b-44e0-b9b1-dfc8b6e49a9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4be1741a-f009-4cea-92b9-094bd017a7ae"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c70244e6-375f-4da3-b1a2-32caf09e36fe"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84286a4f-47ac-47d1-8d90-b56f11a26952"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""05c23d50-0667-4bfd-8f71-e3bb2c126d4c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc33d8a0-8110-46b1-ad5c-90563f3557a2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1063e87c-c432-4b03-9483-0c05ac6689d4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4d751724-3daf-4570-bb64-2eeffccfeebc"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67cdebc1-2df5-49ed-8b3a-a4003c9083b2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ExtraJumpMode"",
            ""id"": ""13c203c6-5fb6-4bd9-830e-0ad66a171e2b"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""0802a597-fdec-4292-a9b0-d76d65c06b08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""371866a2-719d-4dbd-84d6-8468e02183fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""60151a77-23d6-4192-9ac8-ec8ae3b89779"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6640189c-62c5-4a72-bc72-ba257b26d49a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ea7ac7b3-f632-4226-98ad-0d92ab156402"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4f9c43b1-d4e9-4364-ac9b-a76bd753f2b3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b5b6a818-39b9-466f-b77e-6df8a4ca8b16"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ec252fa1-e55b-4131-9926-77958c211b65"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8485d5e3-bb66-48fc-8648-e48fcb41de0e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78c35575-84af-41c7-b01a-ef7e698cef1a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ThrowableMode"",
            ""id"": ""acf524e6-6f31-44d0-befc-816cdafba0d3"",
            ""actions"": [
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""d40d7b9e-93e8-49fd-a65b-b291a2d394d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""5e0e0ff3-8c00-49e1-a6f6-eb77c8eeee6e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""22400f2d-9f67-4b93-895a-43399dcc0f9f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""985e2226-4748-4f91-9a5b-53277f7d2a42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f1d019aa-a980-458a-92d1-22e840d582a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4142d1d7-0753-4e46-8a98-5eb99f1482ee"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b4b313d0-fbae-4203-b7ca-fc549872612e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ca2e45c7-517b-461e-ac56-3855ac4ba49b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""921b5994-3189-4cde-b636-12c5f7ffaf93"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ce04fe8c-92a7-481c-a37d-2e3d923399b2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e63df47f-b053-42f8-be76-59734be092b2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5fc3af83-2407-4a0e-b5f5-917c76fecc2d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Normal (No Powerups)
        m_NormalNoPowerups = asset.FindActionMap("Normal (No Powerups)", throwIfNotFound: true);
        m_NormalNoPowerups_Jump = m_NormalNoPowerups.FindAction("Jump", throwIfNotFound: true);
        m_NormalNoPowerups_Move = m_NormalNoPowerups.FindAction("Move", throwIfNotFound: true);
        m_NormalNoPowerups_Run = m_NormalNoPowerups.FindAction("Run", throwIfNotFound: true);
        // LazerMode
        m_LazerMode = asset.FindActionMap("LazerMode", throwIfNotFound: true);
        m_LazerMode_Jump = m_LazerMode.FindAction("Jump", throwIfNotFound: true);
        m_LazerMode_Move = m_LazerMode.FindAction("Move", throwIfNotFound: true);
        m_LazerMode_Run = m_LazerMode.FindAction("Run", throwIfNotFound: true);
        m_LazerMode_Lazer = m_LazerMode.FindAction("Lazer", throwIfNotFound: true);
        // TeleportMode
        m_TeleportMode = asset.FindActionMap("TeleportMode", throwIfNotFound: true);
        m_TeleportMode_Jump = m_TeleportMode.FindAction("Jump", throwIfNotFound: true);
        m_TeleportMode_Move = m_TeleportMode.FindAction("Move", throwIfNotFound: true);
        m_TeleportMode_Run = m_TeleportMode.FindAction("Run", throwIfNotFound: true);
        m_TeleportMode_Teleport = m_TeleportMode.FindAction("Teleport", throwIfNotFound: true);
        // ExtraJumpMode
        m_ExtraJumpMode = asset.FindActionMap("ExtraJumpMode", throwIfNotFound: true);
        m_ExtraJumpMode_Run = m_ExtraJumpMode.FindAction("Run", throwIfNotFound: true);
        m_ExtraJumpMode_Jump = m_ExtraJumpMode.FindAction("Jump", throwIfNotFound: true);
        m_ExtraJumpMode_Move = m_ExtraJumpMode.FindAction("Move", throwIfNotFound: true);
        // ThrowableMode
        m_ThrowableMode = asset.FindActionMap("ThrowableMode", throwIfNotFound: true);
        m_ThrowableMode_Throw = m_ThrowableMode.FindAction("Throw", throwIfNotFound: true);
        m_ThrowableMode_Run = m_ThrowableMode.FindAction("Run", throwIfNotFound: true);
        m_ThrowableMode_Move = m_ThrowableMode.FindAction("Move", throwIfNotFound: true);
        m_ThrowableMode_Jump = m_ThrowableMode.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Normal (No Powerups)
    private readonly InputActionMap m_NormalNoPowerups;
    private INormalNoPowerupsActions m_NormalNoPowerupsActionsCallbackInterface;
    private readonly InputAction m_NormalNoPowerups_Jump;
    private readonly InputAction m_NormalNoPowerups_Move;
    private readonly InputAction m_NormalNoPowerups_Run;
    public struct NormalNoPowerupsActions
    {
        private @PlayerControls m_Wrapper;
        public NormalNoPowerupsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_NormalNoPowerups_Jump;
        public InputAction @Move => m_Wrapper.m_NormalNoPowerups_Move;
        public InputAction @Run => m_Wrapper.m_NormalNoPowerups_Run;
        public InputActionMap Get() { return m_Wrapper.m_NormalNoPowerups; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NormalNoPowerupsActions set) { return set.Get(); }
        public void SetCallbacks(INormalNoPowerupsActions instance)
        {
            if (m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_NormalNoPowerupsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public NormalNoPowerupsActions @NormalNoPowerups => new NormalNoPowerupsActions(this);

    // LazerMode
    private readonly InputActionMap m_LazerMode;
    private ILazerModeActions m_LazerModeActionsCallbackInterface;
    private readonly InputAction m_LazerMode_Jump;
    private readonly InputAction m_LazerMode_Move;
    private readonly InputAction m_LazerMode_Run;
    private readonly InputAction m_LazerMode_Lazer;
    public struct LazerModeActions
    {
        private @PlayerControls m_Wrapper;
        public LazerModeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_LazerMode_Jump;
        public InputAction @Move => m_Wrapper.m_LazerMode_Move;
        public InputAction @Run => m_Wrapper.m_LazerMode_Run;
        public InputAction @Lazer => m_Wrapper.m_LazerMode_Lazer;
        public InputActionMap Get() { return m_Wrapper.m_LazerMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LazerModeActions set) { return set.Get(); }
        public void SetCallbacks(ILazerModeActions instance)
        {
            if (m_Wrapper.m_LazerModeActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnRun;
                @Lazer.started -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnLazer;
                @Lazer.performed -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnLazer;
                @Lazer.canceled -= m_Wrapper.m_LazerModeActionsCallbackInterface.OnLazer;
            }
            m_Wrapper.m_LazerModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Lazer.started += instance.OnLazer;
                @Lazer.performed += instance.OnLazer;
                @Lazer.canceled += instance.OnLazer;
            }
        }
    }
    public LazerModeActions @LazerMode => new LazerModeActions(this);

    // TeleportMode
    private readonly InputActionMap m_TeleportMode;
    private ITeleportModeActions m_TeleportModeActionsCallbackInterface;
    private readonly InputAction m_TeleportMode_Jump;
    private readonly InputAction m_TeleportMode_Move;
    private readonly InputAction m_TeleportMode_Run;
    private readonly InputAction m_TeleportMode_Teleport;
    public struct TeleportModeActions
    {
        private @PlayerControls m_Wrapper;
        public TeleportModeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_TeleportMode_Jump;
        public InputAction @Move => m_Wrapper.m_TeleportMode_Move;
        public InputAction @Run => m_Wrapper.m_TeleportMode_Run;
        public InputAction @Teleport => m_Wrapper.m_TeleportMode_Teleport;
        public InputActionMap Get() { return m_Wrapper.m_TeleportMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TeleportModeActions set) { return set.Get(); }
        public void SetCallbacks(ITeleportModeActions instance)
        {
            if (m_Wrapper.m_TeleportModeActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnRun;
                @Teleport.started -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_TeleportModeActionsCallbackInterface.OnTeleport;
            }
            m_Wrapper.m_TeleportModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
            }
        }
    }
    public TeleportModeActions @TeleportMode => new TeleportModeActions(this);

    // ExtraJumpMode
    private readonly InputActionMap m_ExtraJumpMode;
    private IExtraJumpModeActions m_ExtraJumpModeActionsCallbackInterface;
    private readonly InputAction m_ExtraJumpMode_Run;
    private readonly InputAction m_ExtraJumpMode_Jump;
    private readonly InputAction m_ExtraJumpMode_Move;
    public struct ExtraJumpModeActions
    {
        private @PlayerControls m_Wrapper;
        public ExtraJumpModeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_ExtraJumpMode_Run;
        public InputAction @Jump => m_Wrapper.m_ExtraJumpMode_Jump;
        public InputAction @Move => m_Wrapper.m_ExtraJumpMode_Move;
        public InputActionMap Get() { return m_Wrapper.m_ExtraJumpMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ExtraJumpModeActions set) { return set.Get(); }
        public void SetCallbacks(IExtraJumpModeActions instance)
        {
            if (m_Wrapper.m_ExtraJumpModeActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnRun;
                @Jump.started -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ExtraJumpModeActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_ExtraJumpModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public ExtraJumpModeActions @ExtraJumpMode => new ExtraJumpModeActions(this);

    // ThrowableMode
    private readonly InputActionMap m_ThrowableMode;
    private IThrowableModeActions m_ThrowableModeActionsCallbackInterface;
    private readonly InputAction m_ThrowableMode_Throw;
    private readonly InputAction m_ThrowableMode_Run;
    private readonly InputAction m_ThrowableMode_Move;
    private readonly InputAction m_ThrowableMode_Jump;
    public struct ThrowableModeActions
    {
        private @PlayerControls m_Wrapper;
        public ThrowableModeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throw => m_Wrapper.m_ThrowableMode_Throw;
        public InputAction @Run => m_Wrapper.m_ThrowableMode_Run;
        public InputAction @Move => m_Wrapper.m_ThrowableMode_Move;
        public InputAction @Jump => m_Wrapper.m_ThrowableMode_Jump;
        public InputActionMap Get() { return m_Wrapper.m_ThrowableMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThrowableModeActions set) { return set.Get(); }
        public void SetCallbacks(IThrowableModeActions instance)
        {
            if (m_Wrapper.m_ThrowableModeActionsCallbackInterface != null)
            {
                @Throw.started -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnThrow;
                @Run.started -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnRun;
                @Move.started -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ThrowableModeActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ThrowableModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public ThrowableModeActions @ThrowableMode => new ThrowableModeActions(this);
    public interface INormalNoPowerupsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface ILazerModeActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLazer(InputAction.CallbackContext context);
    }
    public interface ITeleportModeActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
    }
    public interface IExtraJumpModeActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IThrowableModeActions
    {
        void OnThrow(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
